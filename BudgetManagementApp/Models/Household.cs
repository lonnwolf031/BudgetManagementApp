using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
    internal class Household
    {
        public int Id { get; set; }
        public List<string> People { get; set; }
        public Household()
        {
            People = new List<Person>();
        }
    }
}
