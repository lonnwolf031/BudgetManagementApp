using BudgetManagementApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Data
{
  //TODO make singleton
  public sealed class DBhandler
  {
    private MySqlConnection connection;
    public static string connectionString { get; set; }

    private static readonly Lazy<DBhandler> lazy = new Lazy<DBhandler>(() => new DBhandler());

    public static DBhandler Instance { get { return lazy.Value; } }

    private DBhandler()
    {
      Initialize();
    }

    private void Initialize()
    {
      connection = new MySqlConnection(connectionString);
    }



    public static bool CheckValidity()
    {
      return true;
    }

    public static void Restore()
    {

    }

    public static void Backup()
    {

    }

    private bool OpenConnection()
    {
      try
      {
        connection.Open();
        return true;
      }
      catch (MySqlException ex)
      {
        switch (ex.Number)
        {
          case 0:
            // MessageBox.Show("Kan niet verbinden met de server." + ex.ToString());
            break;

          case 1045:
            //MessageBox.Show("Onjuiste gebruikersnaam en wachtwoord combinatie");
            break;
          default:
            //  MessageBox.Show("Er is een probleem bij het verbinden met de server: " + ex.ToString());
            break;
        }
        return false;
      }
    }

    private bool CloseConnection()
    {
      try
      {
        connection.Close();
        return true;
      }
      catch (MySqlException ex)
      {
        MessageBox.Show(ex.Message);
        return false;
      }
    }

    public void InsertBalance(Balance balance)
    {
      // try
      // {
      using (var cn = new MySqlConnection(connectionString))
      {
        using (MySqlCommand cmd = cn.CreateCommand())
        {
          cmd.CommandText = "INSERT INTO balances VALUES (  id, ?name, ?latest_update, ?expected_balance, ?real_balance)";
          cn.Open();
          cmd.Parameters.Add(new MySqlParameter("?name", balance.Name));
          cmd.Parameters.Add(new MySqlParameter("?latest_update", balance.LatestUpdate));
          cmd.Parameters.Add(new MySqlParameter("?expected_balance", balance.ExpectedBalance));
          cmd.Parameters.Add(new MySqlParameter("?real_balance", balance.RealBalance));
          cmd.ExecuteNonQuery();
        }
      }
      //}
      //catch { }
    }

    public Balance GetBalanceByID(int id)
    {
      Balance balance = new Balance();
      try
      {
        using (var cn = new MySqlConnection(connectionString))
        {
          using (MySqlCommand cmd = cn.CreateCommand())
          {
            cmd.CommandText = "SELECT name, latest_update, expected_balance, real_balance  FROM balances WHERE id = @id";
            cn.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              //int retrievedValue = 0;
              if (reader.HasRows)
              {
                while (reader.Read())
                {
                  balance.Name = (string)reader.GetValue(0);
                  balance.LatestUpdate = (DateTime)reader.GetValue(1);
                  balance.ExpectedBalance = (float)reader.GetValue(2);
                  balance.RealBalance = (float)reader.GetValue(3);
                }
              }
            }
          }
        }
      }
      catch { }
      return balance;
    }

    public ObservableCollection<Balance> GetAllBalances()
    {
      var balances = new ObservableCollection<Balance>();
      var balance = new Balance();
      try
      {
        using (var cn = new MySqlConnection(connectionString))
        {
          using (MySqlCommand cmd = cn.CreateCommand())
          {
            cmd.CommandText = "SELECT name, latest_update, expected_balance, real_balance FROM balances";
            cn.Open();
            using (MySqlDataReader reader = cmd.ExecuteReader())
            {
              //int retrievedValue = 0;
              if (reader.HasRows)
              {
                while (reader.Read())
                {
                  balance.Name = (string)reader.GetValue(0);
                  balance.LatestUpdate = (DateTime)reader.GetValue(1);
                  balance.ExpectedBalance = (float)reader.GetValue(2);
                  balance.RealBalance = (float)reader.GetValue(3);
                  balances.Add(balance);
                }
              }
            }
          }
        }
      }
      catch { }
      return balances;
    }
  }

}
