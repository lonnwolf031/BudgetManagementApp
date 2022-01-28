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
      // listView.ItemSelected += listSelection;

      LoadUI();

      //// listView.ItemTemplate = new DataTemplate(typeof(Label));

      //var dataTemplate = new DataTemplate();
      //var nameLabel = new Label();
      //nameLabel.SetBinding(Label.TextProperty, "Name");
      //dataTemplate.Bindings.Add
      ////titleLabel.SetBinding(Label.TextProperty, "Title");

      //listView.ItemTemplate = dataTemplate;
      //listView.ItemTemplate.SetBinding(EntryCell.LabelProperty, "comment");
      //listView.ItemTemplate.SetBinding(EntryCell.TextProperty, "name");
      // Content = listView;
    }

    private void LoadUI()
    {
      var dataTemplate = new DataTemplate(() =>
      {
        var nameLabel = new Label();
        nameLabel.SetBinding(Label.TextProperty, "Name");

        var latestUpdateLabel = new Label();
        latestUpdateLabel.SetBinding(Label.TextProperty, "LatestUpdate");

        return new StackLayout
        {
          Orientation = StackOrientation.Horizontal,
          Padding = 1,
          HorizontalOptions = LayoutOptions.FillAndExpand,
          Children = {
            new Frame {
              Content = new AbsoluteLayout {
                HorizontalOptions = LayoutOptions.FillAndExpand,
                VerticalOptions = LayoutOptions.FillAndExpand,
                Children = {
                  new StackLayout {
                    Margin = new Thickness(20),
                    VerticalOptions = LayoutOptions.CenterAndExpand,
                    HorizontalOptions = LayoutOptions.CenterAndExpand,
                    Children = {
                      nameLabel,
                      latestUpdateLabel
                    }
                  }
                }
              }
            }
        }
        };
      });

      var listView = new ListView();
      listView.SetBinding(ListView.ItemsSourceProperty, "Items");
      listView.ItemTemplate = dataTemplate;
      listView.BackgroundColor = Color.LightGoldenrodYellow;
      //listView.FlowColumnCount = 1;
      listView.HasUnevenRows = true;

      var button = new Button { Text = "Add" };
      //button.Clicked += Button_Clicked
      //;
      Content = new StackLayout
      {
        Children = {
                    button,
                    listView
                }
      };

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