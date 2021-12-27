using BudgetManagementApp.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BudgetManagementApp.ViewModels
{
  public class BalancesViewModel : INotifyPropertyChanged
  {
    private BalanceRepository balanceRepo = new BalanceRepository();
    private ObservableCollection<Balance> balances;
    public event PropertyChangedEventHandler PropertyChanged;

    public  ObservableCollection<Balance> Balances
    {
      get { return balanceRepo.Items; }
      set
      {
        if (balances != value) {
          balances = value;
          if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs("DateTime"));
          }
        }
        balances = value;
      }
    }

    public  BalancesViewModel()
    {

    }
  }
}
