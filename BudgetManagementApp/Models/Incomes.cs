using System;
using System.Collections.Generic;

namespace BudgetManagementApp.Models
{
  internal class Incomes
  {
    private List<Income> incomes { get; }
    public Incomes()
    {
      incomes = new List<Income>();
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
