using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace BudgetManagementApp.Models
{
  public static class Savings
  {
    static Savings()
    {
    }

    public static ObservableCollection<Saving> getSavings()
    {
      ObservableCollection<Saving> savings = new ObservableCollection<Saving>()
      {
        new Saving(){ SavingGoal = "foo"},
         new Saving(){ SavingGoal = "test"}
      };
      return savings;
    }
  }

  public class Saving : Expenditure, INotifyPropertyChanged
  {

    private string savingGoal;



    public string SavingGoal
    {
      get { return savingGoal; }
      set
      {
        savingGoal = value;
        OnPropertyChanged();
      }
    }


    void OnPropertyChanged([CallerMemberName] string propertyName = null)
    {
      var handler = base.PropertyChanged;
      if (handler != null)
      {
        handler(this, new PropertyChangedEventArgs(propertyName));
      }
    }
  }
}
