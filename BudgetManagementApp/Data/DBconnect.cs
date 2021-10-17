using MySql.Data.MySqlClient;

namespace BudgetManagementApp.data
{
  class dbconnect
  {
    private string connectionstring;

    //constructor
    public dbconnect()
    {
      var connectionstringbuilder = new MySqlConnectionStringBuilder();
      connectionstringbuilder.Server = Constants.server;
      connectionstringbuilder.UserID = Constants.uid;
      connectionstringbuilder.Password = Constants.password;
      connectionstringbuilder.Database = Constants.database;
      //server = constants.server,
      //userid = constants.uid,
      //password = constants.password,
      //database = constants.database
      // certificatefile = @"<path_to_the_file>\client.pfx",
      //certificatepassword = "<password_for_the_cert>"

      connectionstring = connectionstringbuilder.ToString();
    }



    /*
    //backup
    public void backup()
    {
        try
        {
            datetime time = datetime.now;
            int year = time.year;
            int month = time.month;
            int day = time.day;
            int hour = time.hour;
            int minute = time.minute;
            int second = time.second;
            int millisecond = time.millisecond;

            //save file to c:\ with the current date as a filename
            string path;
            path = "c:\\mysqlbackup" + year + "-" + month + "-" + day +
        "-" + hour + "-" + minute + "-" + second + "-" + millisecond + ".sql";
            streamwriter file = new streamwriter(path);


            processstartinfo psi = new processstartinfo();
            psi.filename = "mysqldump";
            psi.redirectstandardinput = false;
            psi.redirectstandardoutput = true;
            psi.arguments = string.format(@"-u{0} -p{1} -h{2} {3}",
                uid, password, server, database);
            psi.useshellexecute = false;

            process process = process.start(psi);

            string output;
            output = process.standardoutput.readtoend();
            file.writeline(output);
            process.waitforexit();
            file.close();
            process.close();
        }
        catch (ioexception ex)
        {
            messagebox.show("error , unable to backup!");
        }
    }

    //restore
    public void restore()
    {
        try
        {
            //read file from c:\
            string path;
            path = "c:\\mysqlbackup.sql";
            streamreader file = new streamreader(path);
            string input = file.readtoend();
            file.close();

            processstartinfo psi = new processstartinfo();
            psi.filename = "mysql";
            psi.redirectstandardinput = true;
            psi.redirectstandardoutput = false;
            psi.arguments = string.format(@"-u{0} -p{1} -h{2} {3}",
                uid, password, server, database);
            psi.useshellexecute = false;


            process process = process.start(psi);
            process.standardinput.writeline(input);
            process.standardinput.close();
            process.waitforexit();
            process.close();
        }
        catch (ioexception ex)
        {
            messagebox.show("error , unable to restore!");
        }
    }

    public async task<account> validatepasswordasync(string username, string password)
    {
        using (var sqlconnection = new mysqlconnection(connectionstring))
        {
            sqlconnection.open();

            var accounts = await sqlconnection.queryasync<account>("select * from hm_accounts where accountaddress = @accountaddress", new
            {
                accountaddress = username
            });

            var account = accounts.singleordefault();

            if (account == null)
                return null;

            // todo: support old hashing methods.
            var salter = new deencrypt();
            if (salter.validatehash(password, account.password))
                return account;

            return null;
        }
    }
    */

    //public async task<ienumerable<person>> getallpeople()
    //{
    //  using (var connection = new mysqlconnection(connectionstring))
    //  {
    //    await connection.openasync();

    //    // read all the userid's and username's from the database, but don't send their password hashes.
    //    var result = await connection.queryasync<person>(@"select userid, username from user");
    //    return result;
    //  }
    //}

    //public async task addperson(person person)
    //{
    //  int id = person.id;
    //  string name = person.name;
    //  double income = person.monthlyincome;
    //  const string sql = "insert into persons(name, surname) values(@name, @surname)";

    //  using (var tran = new transactionscope(transactionscopeasyncflowoption.enabled))
    //  {
    //    // using (var connection = await _connectionprovider.openasync()) //or however you get the connection
    //    using (var conn = new mysqlconnection(connectionstring))
    //    {
    //      await conn.executeasync(sql, new { name, income });
    //      tran.complete();
    //    }
    //  }
    //}





    /*
    public async task<account> getbyidasync(long id)
    {
        using (var sqlconnection = new mysqlconnection(connectionstring))
        {
            sqlconnection.open();

            var accounts = await sqlconnection.queryasync<account>("select * from hm_accounts where accountid = @accountid", new
            {
                accountid = id
            });

            var account = accounts.singleordefault();

            return account;
        }
    }

    public async task<account> getbynameasync(string address)
    {
        using (var sqlconnection = new mysqlconnection(connectionstring))
        {
            sqlconnection.open();

            var accounts = await sqlconnection.queryasync<account>("select * from hm_accounts where accountaddress = @accountaddress", new
            {
                accountaddress = address
            });

            var account = accounts.singleordefault();

            return account;
        }
    }

    public async task<list<artist>> getallasync()
    {
        using (
            sqlconnection conn =
                new sqlconnection(conn.string))
        {
            await conn.openasync();

            using (var multi = await conn.querymultipleasync(storedprocs.artists.getall, commandtype: commandtype.storedprocedure))
            {
                var artists = multi.read<artist, albumartist, artist>((artist, albumartist) =>
                {
                    artist.albumartist = albumartist;
                    return artist;
                }).tolist();

                var albums = multi.read<album, albumartist, album>(
                (album, albumartist, album) =>
                {
                    album.albumartist = album;
                    return albums;
                }).tolist();


                conn.close();

                return artists;
            }
        }
    }
    */


  }
}
