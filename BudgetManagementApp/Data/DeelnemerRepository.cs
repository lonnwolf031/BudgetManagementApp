using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVMbezettingApp.ViewModel;
using MVVMbezettingApp.Model;

namespace MVVMbezettingApp
{
    class BudgetItemRepository
    {
        private static List<BudgetItem> budgetItems = new List<BudgetItem>();

        internal void Add(BudgetItem budgetItem)
        {
            budgetItems.Add(budgetItem);
        }
        
        internal void Remove(BudgetItem budgetItem)
        {
            budgetItems.Remove(budgetItem);
        }

        internal BudgetItem Search(int id)
        {
            //Get the budgetItems index in the collection
            int index = GetIndex(id);
            //If present then return the element
            if (index > -1)
                return budgetItems[index];
            return null;
        }

        private int GetIndex(int id)
        {
            int index = -1;
            //If Collection has Items
            if (budgetItems.Count > 0)
            {
                //Loop through the collection
                for (int i = 0; i < budgetItems.Count; i++)
                {
                    //If match
                    if (budgetItems[i].Id == id)
                    {
                        index = i;
                        break;
                    }
                }
            }
            return index;
        }
    }
}
