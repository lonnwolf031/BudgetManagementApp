using BudgetManagementApp.ViewModels;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BalancesPage : ContentPage
  {
    private BalancesViewModel balancesViewModel;
    public BalancesPage()
    {
      InitializeComponent();
      balancesViewModel = new BalancesViewModel();
      this.BindingContext = balancesViewModel;
      listView.ItemSelected += listSelection;

      listView.ItemTemplate = new DataTemplate(typeof(EntryCell));
      listView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "comment");
      listView.ItemTemplate.SetBinding(EntryCell.TextProperty, "name");
      Content = listView;
    }

    protected async override void OnAppearing()
    {
      await Task.Run(() =>
      {
        //do thing
      });
    }

    async void OnButtonAddClicked(object sender, EventArgs args)
    {
      await Navigation.PushAsync(new AddEditBalancePage());
    }

    void listSelection(object sender, SelectedItemChangedEventArgs e)
    {
      ((ListView)sender).SelectedItem = null;
    }
  }
}