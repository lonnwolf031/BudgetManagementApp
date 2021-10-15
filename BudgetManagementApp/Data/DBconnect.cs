using System;
using System.Collections.Generic;
using System.Text;
using MySql.Data.MySqlClient;
using Dapper;
using System.Threading.Tasks;
using System.IO;
using System.Transactions;
using BudgetManagementApp.Models;

namespace BudgetManagementApp.Data
{
    class DBConnect
    {
        private string connectionString;

        //Constructor
        public DBConnect()
        {
            var connectionStringBuilder = new MySqlConnectionStringBuilder
            {
                Server = Constants.server,
                UserID = Constants.uid,
                Password = Constants.password,
                Database = Constants.database
               // CertificateFile = @"<Path_To_The_File>\client.pfx",
                //CertificatePassword = "<Password_For_The_Cert>"
            };
            connectionString = connectionStringBuilder.ToString();
        }



        /*
        //Backup
        public void Backup()
        {
            try
            {
                DateTime Time = DateTime.Now;
                int year = Time.Year;
                int month = Time.Month;
                int day = Time.Day;
                int hour = Time.Hour;
                int minute = Time.Minute;
                int second = Time.Second;
                int millisecond = Time.Millisecond;

                //Save file to C:\ with the current date as a filename
                string path;
                path = "C:\\MySqlBackup" + year + "-" + month + "-" + day +
            "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
                StreamWriter file = new StreamWriter(path);


                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysqldump";
                psi.RedirectStandardInput = false;
                psi.RedirectStandardOutput = true;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;

                Process process = Process.Start(psi);

                string output;
                output = process.StandardOutput.ReadToEnd();
                file.WriteLine(output);
                process.WaitForExit();
                file.Close();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to backup!");
            }
        }

        //Restore
        public void Restore()
        {
            try
            {
                //Read file from C:\
                string path;
                path = "C:\\MySqlBackup.sql";
                StreamReader file = new StreamReader(path);
                string input = file.ReadToEnd();
                file.Close();

                ProcessStartInfo psi = new ProcessStartInfo();
                psi.FileName = "mysql";
                psi.RedirectStandardInput = true;
                psi.RedirectStandardOutput = false;
                psi.Arguments = string.Format(@"-u{0} -p{1} -h{2} {3}",
                    uid, password, server, database);
                psi.UseShellExecute = false;


                Process process = Process.Start(psi);
                process.StandardInput.WriteLine(input);
                process.StandardInput.Close();
                process.WaitForExit();
                process.Close();
            }
            catch (IOException ex)
            {
                MessageBox.Show("Error , unable to Restore!");
            }
        }

        public async Task<Account> ValidatePasswordAsync(string username, string password)
        {
            using (var sqlConnection = new MySqlConnection(connectionString))
            {
                sqlConnection.Open();

                var accounts = await sqlConnection.QueryAsync<Account>("SELECT * FROM hm_accounts WHERE accountaddress = @accountaddress", new
                {
                    accountaddress = username
                });

                var account = accounts.SingleOrDefault();

                if (account == null)
                    return null;

                // TODO: Support old hashing methods.
                var salter = new Deencrypt();
                if (salter.ValidateHash(password, account.Password))
                    return account;

                return null;
            }
        }
        */

        public async Task<IEnumerable<Person>> GetAllPeople()
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                await connection.OpenAsync();

                // Read all the userId's and userName's from the database, but don't send their password hashes.
                var result = await connection.QueryAsync<Person>(@"SELECT UserId, UserName FROM User");
                return result;
            }
        }

        public async Task AddPerson(Person person)
        {
            int id = person.Id;
            String name = person.Name;
            double Income = person.MonthlyIncome;
            const string sql = "insert into Persons(Name, Surname) values(@Name, @Surname)";

            using (var tran = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                // using (var connection = await _connectionProvider.OpenAsync()) //Or however you get the connection
                using (var conn = new MySqlConnection(connectionString))
                {
                    await conn.ExecuteAsync(sql, new { name, Income });
                    tran.Complete();
                }
            }
        }

    private void Backup()
    {
      string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
      string file = "C:\\backup.sql";
      using (MySqlConnection conn = new MySqlConnection(constring))
      {
        using (MySqlCommand cmd = new MySqlCommand())
        {
          using (MySqlBackup mb = new MySqlBackup(cmd))
          {
            cmd.Connection = conn;
            conn.Open();
            mb.ExportToFile(file);
            conn.Close();
          }
        }
      }
    }

    private void Restore()
    {
      string constring = "server=localhost;user=root;pwd=qwerty;database=test;";
      string file = "C:\\backup.sql";
      using (MySqlConnection conn = new MySqlConnection(constring))
      {
        using (MySqlCommand cmd = new MySqlCommand())
        {
          using (MySqlBackup mb = new MySqlBackup(cmd))
          {
            cmd.Connection = conn;
            conn.Open();
            mb.ImportFromFile(file);
            conn.Close();
          }
        }
      }
    }

    /*
    public async Task<Account> GetByIdAsync(long id)
    {
        using (var sqlConnection = new MySqlConnection(connectionString))
        {
            sqlConnection.Open();

            var accounts = await sqlConnection.QueryAsync<Account>("SELECT * FROM hm_accounts WHERE accountid = @accountid", new
            {
                accountid = id
            });

            var account = accounts.SingleOrDefault();

            return account;
        }
    }

    public async Task<Account> GetByNameAsync(string address)
    {
        using (var sqlConnection = new MySqlConnection(connectionString))
        {
            sqlConnection.Open();

            var accounts = await sqlConnection.QueryAsync<Account>("SELECT * FROM hm_accounts WHERE accountaddress = @accountaddress", new
            {
                accountaddress = address
            });

            var account = accounts.SingleOrDefault();

            return account;
        }
    }

    public async Task<List<Artist>> GetAllAsync()
    {
        using (
            SqlConnection conn =
                new SqlConnection(Conn.String))
        {
            await conn.OpenAsync();

            using (var multi = await conn.QueryMultipleAsync(StoredProcs.Artists.GetAll, commandType: CommandType.StoredProcedure))
            {
                var Artists = multi.Read<Artist, AlbumArtist, Artist>((artist, albumArtist) =>
                {
                    artist.albumArtist = albumArtist;
                    return artist;
                }).ToList();

                var albums = multi.Read<Album, AlbumArtist, Album>(
                (album, albumArtist, album) =>
                {
                    album.albumArtist = album;
                    return albums;
                }).ToList();


                conn.Close();

                return Artists;
            }
        }
    }
    */


  }
}
