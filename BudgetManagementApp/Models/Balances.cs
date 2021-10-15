using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
  public class Balances
  {
    private List<Balance> balances;
  }

  public class Balance
  {
    private int id;
    private string name;
    private DateTime latestUpdate;
    private float expectedBalance;
    private float realBalance;
  }
}
