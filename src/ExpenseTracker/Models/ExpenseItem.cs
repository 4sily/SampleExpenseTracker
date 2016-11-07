using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ExpenseItem
    {
        public string Key { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public decimal Amount { get; set; }
        public string Comment { get; set; }
    }
}
