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

    private void loadView()
    {
      ListView listView = new ListView() { SeparatorVisibility = SeparatorVisibility.None, ItemsSource = HomeViewModel.lights };
      listView.ItemTemplate = new DataTemplate(typeof(EntryCell));
      listView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "comment");
      listView.ItemTemplate.SetBinding(EntryCell.TextProperty, "name");
      Content = listView;
    }
  }
}