using BudgetManagementApp.Models;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class ExpendituresViewModel
  {
    public static ObservableCollection<Expenditure> expenditures { get; set; }

    static ExpendituresViewModel()
    {
      expenditures = Expenditures.getExpenditures();
    }
  }
}
