using System;
using System.Collections.Generic;

namespace BudgetManagementApp.Models
{
  public class Balances
  {
    public List<Balance> balances { get; }
    public Balances()
    {
      balances = new List<Balance>();
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
