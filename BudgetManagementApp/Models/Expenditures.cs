using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

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
        new Expenditure(){ ExpenditureSource = "foo"},
         new Expenditure(){ ExpenditureSource = "test"}
      };
      return expenditures;
    }
  }

  public class Expenditure : INotifyPropertyChanged
  {
    private int id;
    private DateTime date;
    private int repeatDays;
    private string expenditureSource;
    private float expectedAmount;
    private float realAmount;

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
    public int RepeatDays
    {
      get { return repeatDays; }
      set
      {
        repeatDays = value;
        OnPropertyChanged();
      }
    }
    public string ExpenditureSource
    {
      get { return expenditureSource; }
      set
      {
        expenditureSource = value;
        OnPropertyChanged();
      }
    }

    public float ExpectedAmount
    {
      get { return expectedAmount; }
      set
      {
        expectedAmount = value;
        OnPropertyChanged();
      }
    }

    public float RealAmount
    {
      get { return realAmount; }
      set
      {
        realAmount = value;
        OnPropertyChanged();
      }
    }

    protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }



}
