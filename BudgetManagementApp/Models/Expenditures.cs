using System;
using System.Collections.Generic;

namespace BudgetManagementApp.Models
{
  internal class Expenditures
  {
    public List<Expenditure> expenditures { get; }
    public Expenditures()
    {
      expenditures = new List<Expenditure>();
    }
  }
  public class Expenditure
  {
    public int id { get; }
    public DateTime date { get; set; }
    public int repeatDays { get; set; }
    public string expenditureSourc { get; set; }
    public float expectedAmount { get; set; }
    public float realAmount { get; set; }
  }
}
