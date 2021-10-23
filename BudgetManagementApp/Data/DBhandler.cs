using BudgetManagementApp.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Data
{
  //TODO make singleton
  public sealed class DBhandler
  {
    private static readonly Lazy<DBhandler> lazy = new Lazy<DBhandler>(() => new DBhandler());

    public static DBhandler Instance { get { return lazy.Value; } }

    private DBhandler() { }

    public static string connectionString { get; set; }

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

    public void InsertBalance(Balance balance)
    {
      try
      {
        using (var cn = new MySqlConnection(connectionString))
        {
          string SQLcommand = "INSERT INTO balances (id, name, latest_update, expected_balance, real_balance) VALUES(?id, ?name, ?latestupdate, ?expectedbalance, ?realbalance);";
          using (MySqlCommand cmd = cn.CreateCommand())
          {
            cmd.CommandText = "INSERT INTO balances (id, name, latest_update, expected_balance, real_balance)";
            cn.Open();

            cn.Open();

            cmd.Parameters.Add(new MySqlParameter("?name", balance.Name));
            cmd.Parameters.Add(new MySqlParameter("?latestupdate", balance.LatestUpdate));
            cmd.Parameters.Add(new MySqlParameter("?expectedbalance", balance.ExpectedBalance));
            cmd.Parameters.Add(new MySqlParameter("?realbalance", balance.RealBalance));

            cmd.ExecuteNonQuery();
          }
        }
      }
      catch { }
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
