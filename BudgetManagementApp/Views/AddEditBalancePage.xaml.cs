using BudgetManagementApp.Data;
using BudgetManagementApp.Models;
using System;
using System.Globalization;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class AddEditBalancePage : ContentPage
  {
    private bool isNewItem;

    public AddEditBalancePage()
    {
      InitializeComponent();
      isNewItem = true;
    }
    public AddEditBalancePage(Balance balance)
    {
      isNewItem = false;
      entryName.Text = balance.Name;
      datePicker.Date = balance.LatestUpdate;
      entryExpBalance.Text = balance.ExpectedBalance.ToString();
      entryRealBalance.Text = balance.RealBalance.ToString();
    }

    async void OnButtonClicked(object sender, EventArgs args)
    {
      await Task.Run(() =>
      {
        Balance balance = new Balance();
        balance.Name = (string)entryName.Text;
        balance.LatestUpdate = (DateTime)datePicker.Date;
        float expBalance, realBalance;
        float.TryParse(entryExpBalance.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out expBalance);
        float.TryParse(entryRealBalance.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out realBalance);
        balance.ExpectedBalance = expBalance;
        balance.RealBalance = realBalance;
        DBhandler.Instance.InsertBalance(balance);
      });
    }
  }
}