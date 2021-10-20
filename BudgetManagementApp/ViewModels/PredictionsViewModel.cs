using BudgetManagementApp.Models;
using System.Collections.ObjectModel;

namespace BudgetManagementApp.ViewModels
{
  public static class PredictionsViewModel
  {
    public static ObservableCollection<Prediction> predictions { get; set; }

    static PredictionsViewModel()
    {
      predictions = Predictions.getPredictions();
    }
  }
}
