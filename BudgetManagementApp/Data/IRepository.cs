using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace BudgetManagementApp.Data
{
    public interface IRepository<T>
    {
        ObservableCollection<T> Items { get; }
        T GetTByID(int itemId);
        void InsertItem(T item);
        void DeleteItem(int itemID);
        void UpdateItem(T item);

    }
}
