using BudgetManagementApp.Views;
using System;
using System.Collections.Generic;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;


namespace BudgetManagementApp
{
  public partial class AppShell : Shell
  {
    public Dictionary<string, Type> Routes { get; private set; } = new Dictionary<string, Type>();

    public ICommand HelpCommand => new Command<string>(async (url) => await Launcher.OpenAsync(url));

    public AppShell()
    {
      InitializeComponent();
      RegisterRoutes();
      BindingContext = this;
    }

    void RegisterRoutes()
    {
      Routes.Add("Account", typeof(AccountPage));
      Routes.Add("Balances", typeof(BalancesPage));
      Routes.Add("Incomes", typeof(IncomesPage));
      Routes.Add("Expenditures", typeof(ExpendituresPage));
      Routes.Add("Predictions", typeof(PredictionsPage));
      Routes.Add("Settings", typeof(SettingsPage));
      Routes.Add("Overview", typeof(OverviewPage));
      //Routes.Add("overviewhouseholdpage", typeof(OverviewHouseholdPage));
      //Routes.Add("overviewyearpage", typeof(OverviewYearPage));
      ////Routes.Add("monkeydetails", typeof(MonkeyDetailPage));
      //Routes.Add("beardetails", typeof(BearDetailPage));
      //Routes.Add("catdetails", typeof(CatDetailPage));
      //Routes.Add("dogdetails", typeof(DogDetailPage));
      //Routes.Add("elephantdetails", typeof(ElephantDetailPage));

      foreach (var item in Routes)
      {
        Routing.RegisterRoute(item.Key, item.Value);
      }
    }

  }
}
