using MySql.Data.MySqlClient;

namespace BudgetManagementApp
{
  public static class Constants
  {
    public static string ConnectionStr { get; set; }

    public static string ConnectionString(string server, string uid, string password, string database)
    {
      var connectionstringbuilder = new MySqlConnectionStringBuilder();
      connectionstringbuilder.Server = server;
      connectionstringbuilder.UserID = uid;
      connectionstringbuilder.Password = password;
      connectionstringbuilder.Database = database;
      return connectionstringbuilder.ToString();
    }
  }
}
