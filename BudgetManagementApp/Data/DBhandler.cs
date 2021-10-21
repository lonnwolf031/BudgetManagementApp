using BudgetManagementApp.Models;
using Dapper;
using MySql.Data.MySqlClient;
using System;
using System.Collections.ObjectModel;
using System.Linq;

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

    public bool InsertBalance(Balance balance)
    {
      int x = -1;
      using (var connection = new MySqlConnection(connectionString))
      {
        connection.Open();
        var sqlStatement = @"
          INSERT INTO balances (id, name, latest_update, expected_balance, real_balance)";
        x = connection.Execute(sqlStatement, balance);
      }
      return x > 0;
    }

    public Balance GetBalanceByID(int id)
    {
      using (var cn = new MySqlConnection(connectionString))
      {
        string query = "SELECT * FROM Balance WHERE id = @id";
        cn.Open();
        var result = cn.Query<Balance>(query, new { Id = id }).First();
        return result;
      }
    }

    public ObservableCollection<Balance> QueryAllBalances()
    {
      using (var cn = new MySqlConnection(connectionString))
      {
        var sql = "select name, latest_update, expected_balance, real_balance  from balances";
        var result = cn.Query<Balance>(sql);
        Console.WriteLine(result.ToString());
        var balances = new ObservableCollection<Balance>(result);
        return balances;
      }
    }
  }

}
