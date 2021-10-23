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
        var expBalance;

        balance.ExpectedBalance = float.TryParse(entryExpBalance.Text, NumberStyles.Float, CultureInfo.InvariantCulture, out expBalance);
        balance.RealBalance = (float)entryRealBalance.Text;
        DBhandler.Instance.InsertBalance(balance);
      });
    }
  }
}