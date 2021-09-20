using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BudgetManagementApp.Models;

namespace BudgetManagementApp
{
    class BudgetItemManager
    {
        readonly BudgetItemRepository budgetItemRepository;

        public BudgetItemManager()
        {
            budgetItemRepository = new BudgetItemRepository();
        }

        public bool Add(BudgetItem budgetItem)
        {
            //Search if the budgetItem exists and if not add the budgetItem.
            if (budgetItemRepository.Search(budgetItem.Id) == null)
            {
                budgetItemRepository.Add(budgetItem);
                return true;
            }
            return false;
        }

        public bool Remove(int id)
        {
            //Search if the budgetItem exists and if exists remove the budgetItem.
            BudgetItem budgetItem = budgetItemRepository.Search(id);
            if (budgetItem != null)
            {
                budgetItemRepository.Remove(budgetItem);
                return true;
            }
            return false;
        }

        public BudgetItem Search(int id)
        {
            return budgetItemRepository.Search(id);
        }
    }
}
