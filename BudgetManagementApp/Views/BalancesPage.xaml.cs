using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BudgetManagementApp.Views
{
  [XamlCompilation(XamlCompilationOptions.Compile)]
  public partial class BalancesPage : ContentPage
  {

    public BalancesPage()
    {
      InitializeComponent();
    }

    protected async override void OnAppearing()
    {
      await Task.Run(() =>
      {
        //do thing
      });
    }


    void listSelection(object sender, SelectedItemChangedEventArgs e)
    {
      ((ListView)sender).SelectedItem = null;
    }
  }
}