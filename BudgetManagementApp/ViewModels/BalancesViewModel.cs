using BudgetManagementApp.Models;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class BalancesViewModel
  {
    private static BalanceRepository balanceRepo = new BalanceRepository();
    public static ObservableCollection<Balance> balances
    {
      get => balanceRepo.Items;
      set => balances = value;
    }

    static BalancesViewModel()
    {

    }
  }
}
