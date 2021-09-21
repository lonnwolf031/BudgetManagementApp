using System;
using System.Collections.Generic;
using System.Text;

namespace BudgetManagementApp.Models
{
    public class Household
    {
        public int Id { get; set; }
        public List<Person> People { get; set; }
        public Household()
        {
            People = new List<Person>();
        }
    }
}
