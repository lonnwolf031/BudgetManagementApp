using System;
using System.Collections.ObjectModel;

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
        new Prediction(){ name = "foo"},
         new Prediction(){ name = "test"}
      };
      return predictions;
    }
  }
  public class Prediction
  {
    public int id { get; }
    public DateTime startDate { get; set; }
    public int source { get; set; }
    public bool increment { get; set; }
    public float amount { get; set; }
  }
}
