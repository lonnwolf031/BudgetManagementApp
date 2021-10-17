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
        // Constants.ConnectionStr = Constants.ConnectionString(connectServer, connectUid, connectpwd, connectDb);
        Constants.ConnectionStr = Constants.ConnectionString("localhost", "root", "root", connectDb);
      });
    }
  }
}