using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Models
{

  public static class Balances
  {
    static Balances()
    {
    }

    public static ObservableCollection<Balance> getBalances()
    {
      ObservableCollection<Balance> balances = new ObservableCollection<Balance>()
      {
        new Balance(){ name = "foo"},
         new Balance(){ name = "test"}
      };
      return balances;
    }
  }

  public class Balance
  {
    public int id { get; }
    public string name { get; set; }
    public DateTime latestUpdate { get; set; }
    public float expectedBalance { get; set; }
    public float realBalance { get; set; }
  }
}
