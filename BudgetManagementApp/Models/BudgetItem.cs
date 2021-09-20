using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
    internal class BudgetItem
    {
        public int Id { get; set; }

        public List<string> Somelist { get; set; }
        public BudgetItem()
        {
            Somelist = new List<string>();
        }
    }
}
