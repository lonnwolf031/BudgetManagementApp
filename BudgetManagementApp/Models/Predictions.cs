using System;
using System.Collections.Generic;

namespace BudgetManagementApp.Models
{
  internal class Predictions
  {
    public List<Prediction> predictions { get; }
    public Predictions()
    {
      predictions = new List<Prediction>();
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
