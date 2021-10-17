using System;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AccountPage : ContentPage
  {
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
      Constants.ConnectionStr = Constants.ConnectionString(connectServer, connectUid, connectpwd, connectDb);

      //await 
    }
  }
}