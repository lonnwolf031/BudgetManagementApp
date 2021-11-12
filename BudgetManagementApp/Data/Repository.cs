using BudgetManagementApp.Data;
using System;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.Models
{
  public interface IRepository<T>
  {
    ObservableCollection<T> Items { get; }
    T GetTByID(int itemId);
    void InsertItem(T item);
    void DeleteItem(int itemID);
    void UpdateItem(T item);

  }

  public class BalanceRepository : IRepository<Balance>
  {
    ObservableCollection<Balance> balances = new ObservableCollection<Balance>();

    public void DeleteItem(int id)
    {
      DBhandler.Instance.RemoveBalance(id);
    }

    public Balance GetTByID(int itemId)
    {
      throw new NotImplementedException();
    }

    public void InsertItem(Balance item)
    {
      DBhandler.Instance.InsertBalance(item);
      balances.Add(item);
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
