using BudgetManagementApp.Data;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetManagementApp.Models
{

  public class BalanceRepository : IRepository<Balance>
  {
    ObservableCollection<Balance> balances = new ObservableCollection<Balance>();

    public void DeleteItem(int itemID)
    {
      throw new NotImplementedException();
    }

    public void Dispose()
    {
      throw new NotImplementedException();
    }

    public IEnumerable<Balance> GetItems()
    {
      balances = DBhandler.Instance.GetAllBalances();
      return balances;
    }

    public Balance GetTByID(int itemId)
    {
      throw new NotImplementedException();
    }

    public void InsertItem(Balance item)
    {
      throw new NotImplementedException();
    }

    public void Save()
    {
      throw new NotImplementedException();
    }

    public void UpdateItem(Balance item)
    {
      throw new NotImplementedException();
    }
  }

  public static class Balances
  {
    static Balances()
    {
    }

    public static ObservableCollection<Balance> getBalances()
    {
      ObservableCollection<Balance> balances = new ObservableCollection<Balance>();
      balances = DBhandler.Instance.GetAllBalances();
      return balances;
    }
  }

  public class Balance : INotifyPropertyChanged
  {
    private int id;
    private string name;
    private DateTime latestUpdate;
    private float expectedBalance;
    private float realBalance;

    public event PropertyChangedEventHandler PropertyChanged;

    public int Id
    {
      get { return id; }
      set
      {
        id = value;
        OnPropertyChanged();
      }
    }
    public string Name
    {
      get { return name; }
      set
      {
        name = value;
        OnPropertyChanged();
      }
    }
    public DateTime LatestUpdate
    {
      get { return latestUpdate; }
      set
      {
        latestUpdate = value;
        OnPropertyChanged();
      }
    }
    public float ExpectedBalance
    {
      get { return expectedBalance; }
      set
      {
        expectedBalance = value;
        OnPropertyChanged();
      }
    }
    public float RealBalance
    {
      get { return realBalance; }
      set
      {
        realBalance = value;
        OnPropertyChanged();
      }
    }

    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
