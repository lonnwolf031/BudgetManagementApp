using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetManagementApp.Models
{
  public static class Incomes
  {
    static Incomes()
    {
    }

    public static ObservableCollection<Income> getIncomes()
    {
      ObservableCollection<Income> incomes = new ObservableCollection<Income>()
      {
        new Income(){ IncomeSource = "foo"},
         new Income(){IncomeSource = "test"}
      };
      return incomes;
    }
  }

  public class Income : INotifyPropertyChanged
  {
    private int id;
    private DateTime date;
    private string incomeSource;
    private float amountExpected;
    private float amountReal;



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

    public DateTime Date
    {
      get { return date; }
      set
      {
        date = value;
        OnPropertyChanged();
      }
    }
    public string IncomeSource
    {
      get { return incomeSource; }
      set
      {
        incomeSource = value;
        OnPropertyChanged();
      }
    }
    public float AmountExpected
    {
      get { return amountExpected; }
      set
      {
        amountExpected = value;
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
