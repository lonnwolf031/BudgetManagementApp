using Xamarin.Forms;
using BudgetManagementApp.ViewModels;

namespace BudgetManagementApp.Views
{
    public partial class MonkeyDetailPage : ContentPage
    {
        public MonkeyDetailPage()
        {
            InitializeComponent();
            BindingContext = new MonkeyDetailViewModel();
        }
    }
}