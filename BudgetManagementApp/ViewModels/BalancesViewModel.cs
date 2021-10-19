using BudgetManagementApp.Models;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class BalancesViewModel
  {
    public static ObservableCollection<Balance> balances { get; set; }

    static BalancesViewModel()
    {
      BalancesViewModel.balances = Balances.getBalances();
    }
  }
}
