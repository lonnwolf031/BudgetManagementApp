using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetManagementApp.Models
{



  //public static class Balances
  //{
  //  static Balances()
  //  {
  //  }

  //  public static ObservableCollection<Balance> getBalances()
  //  {
  //    ObservableCollection<Balance> balances = new ObservableCollection<Balance>();
  //    balances = DBhandler.Instance.GetAllBalances();
  //    return balances;
  //  }
  //}

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
