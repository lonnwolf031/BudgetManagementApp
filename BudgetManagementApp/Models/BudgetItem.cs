using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
    internal class BudgetItem
    {
        public int Id { get; set; }
        public String Name { get; set; }
        public String Description { get; set; }
        public double DedicatedAount { get; set; }
        public double RealAmount { get; set; }

        public List<string> Somelist { get; set; }
        public BudgetItem()
        {
            Somelist = new List<string>();
        }
    }
}
