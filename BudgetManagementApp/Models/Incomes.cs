using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
  internal class Incomes
  {
    private List<Income> incomes;
  }

  public class Income 
  {
    private int id;
    private DateTime date;
    private string incomeSource;
    private float amountExpected;
    private float amountReal;
  
  }

}
