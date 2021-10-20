using BudgetManagementApp.Models;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class IncomesViewModel
  {
    public static ObservableCollection<Income> incomes { get; set; }

    static IncomesViewModel()
    {
      incomes = Incomes.getIncomes();
    }
  }
}
