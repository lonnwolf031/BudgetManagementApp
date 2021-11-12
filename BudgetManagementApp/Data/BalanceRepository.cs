using BudgetManagementApp.Data;
using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Models
{


  public class BalanceRepository : IRepository<Balance>
  {
    ObservableCollection<Balance> balances = new ObservableCollection<Balance>();

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
    }
  }
}
