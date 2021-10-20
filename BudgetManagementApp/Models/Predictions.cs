using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetManagementApp.Models
{
  public static class Predictions
  {
    static Predictions()
    {
    }

    public static ObservableCollection<Prediction> getPredictions()
    {
      ObservableCollection<Prediction> predictions = new ObservableCollection<Prediction>()
      {
        new Prediction(){ Id = 5},
         new Prediction(){ Id = 2}
      };
      return predictions;
    }
  }

  public class Prediction : INotifyPropertyChanged
  {
    public int id;
    public DateTime startDate;
    public int source;
    public bool increment;
    public float amount;

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

    public DateTime StartDate
    {
      get { return startDate; }
      set
      {
        startDate = value;
        OnPropertyChanged();
      }
    }
    public int Source
    {
      get { return source; }
      set
      {
        source = value;
        OnPropertyChanged();
      }
    }
    public bool Increment
    {
      get { return increment; }
      set
      {
        increment = value;
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
