using System.Collections.Generic;

namespace BudgetManagementApp.Models
{
  public interface IRepository<T>
  {
    IEnumerable<T> GetItems();
    T GetTByID(int itemId);
    void InsertItem(T item);
    void DeleteItem(int itemID);
    void UpdateItem(T item);
    void Save();
  }
}
