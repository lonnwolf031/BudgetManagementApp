using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Models
{
  public static class Incomes
  {
    static Incomes()
    {
    }

    public static ObservableCollection<Income> getIncomes()
    {
      ObservableCollection<Income> incomes = new ObservableCollection<Income>()
      {
        new Income(){ name = "foo"},
         new Income(){ name = "test"}
      };
      return incomes;
    }
  }

  public class Income
  {
    private int id { get; }
    private DateTime date { get; set; }
    private string incomeSource { get; set; }
    private float amountExpected { get; set; }
    private float amountReal { get; set; }

  }

}
