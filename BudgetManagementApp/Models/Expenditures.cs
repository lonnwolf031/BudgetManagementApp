using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Models
{
  public static class Expenditures
  {
    static Expenditures()
    {
    }

    public static ObservableCollection<Expenditure> getExpenditures()
    {
      ObservableCollection<Expenditure> expenditures = new ObservableCollection<Expenditure>()
      {
        new Expenditure(){ name = "foo"},
         new Expenditure(){ name = "test"}
      };
      return expenditures;
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
