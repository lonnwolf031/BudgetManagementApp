using BudgetManagementApp.Data;
using MySql.Data.MySqlClient;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AccountPage : ContentPage
  {
    //TODO: store data for keeping state between sessiosn

    public AccountPage()
    {
      InitializeComponent();
    }

    async void OnButtonConnectClicked(object sender, EventArgs args)
    {
      string connectServer = entryServer.Text;
      string connectUid = entryUserID.Text;
      string connectpwd = entryPwc.Text;
      string connectDb = entryDb.Text;

      await Task.Run(() =>
      {
        DBhandler.connectionString = ConnectionString("localhost", "root", "root", "budgetmanagementappdb");
        var statusabel = new Label { Text = "Connectionstring succeeded" };
      });
    }

    public static string ConnectionString(string server, string uid, string password, string database)
    {
      var connectionstringbuilder = new MySqlConnectionStringBuilder();
      connectionstringbuilder.Server = server;
      connectionstringbuilder.UserID = uid;
      connectionstringbuilder.Password = password;
      connectionstringbuilder.Database = database;
      connectionstringbuilder.SslMode = MySqlSslMode.None;
      return connectionstringbuilder.ToString();
    }
  }
}