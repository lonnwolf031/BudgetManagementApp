using BudgetManagementApp.Models;
using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class BalancesViewModel
  {
    public static ObservableCollection<Balance> balances { get; set; }

    static BalancesViewModel()
    {
      try
      {
        balances = Balances.getBalances();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }
    }
  }
  public class BalancesViewModel1
  {
    public static ObservableCollection<Balance> balances { get; set; }

    public BalancesViewModel1()
    {
      try
      {
        balances = Balances.getBalances();
      }
      catch (Exception e)
      {
        Console.WriteLine(e.ToString());
      }
    }

    public void Add(Balance balance)
    {
      balances.Add(balance);
    }
  }
}
