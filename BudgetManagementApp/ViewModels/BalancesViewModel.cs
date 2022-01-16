using BudgetManagementApp.Data;
using BudgetManagementApp.Models;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace BudgetManagementApp.ViewModels
{

  public class BalancesViewModel : IRepository<Balance>, INotifyPropertyChanged
  {

    private ObservableCollection<Balance> balances;
    public event PropertyChangedEventHandler PropertyChanged;


    public BalancesViewModel()
    {
      balances = new ObservableCollection<Balance>();
    }

    public void DeleteItem(int id)
    {
      DBhandler.Instance.RemoveBalance(id);
    }

    public Balance GetTByID(int itemId)
    {
      return DBhandler.Instance.GetBalanceByID(itemId);
    }

    public void InsertItem(Balance item)
    {
      DBhandler.Instance.InsertBalance(item);
    }


    public void UpdateItem(Balance item)
    {
      throw new NotImplementedException();
    }

    public ObservableCollection<Balance> Items
    {
      get => balances = DBhandler.Instance.GetAllBalances();
      set
      {
        if (balances != value) {
          balances = value;
          if (PropertyChanged != null) {
            PropertyChanged(this, new PropertyChangedEventArgs("Balances"));
          }
        }
        balances = value;
      }
    }
  }
}