using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
  internal class Expenditures
  {
    private List<Expenditure> expenditures;
  }
  public class Expenditure
  {
    private int id;
    private DateTime date;
    private int repeatDays;
    private string expenditureSource;
    private float expectedAmount;
    private float realAmount;
  }
}
