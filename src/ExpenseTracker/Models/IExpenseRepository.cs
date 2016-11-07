using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public interface IExpenseRepository
    {
        void Add(ExpenseItem item);
        IEnumerable<ExpenseItem> GetAll();
        ExpenseItem Find(string key);
        ExpenseItem Remove(string key);
        void Update(ExpenseItem item);

        // Filtering by date
        IEnumerable<ExpenseItem> GetAllBetween(DateTime from, DateTime to);
        IEnumerable<ExpenseItem> GetAllBefore(DateTime timePoint);
        IEnumerable<ExpenseItem> GetAllAfter(DateTime timePoint);

        // Filtering by amount
        IEnumerable<ExpenseItem> GetAllMoreThan(decimal amount);
        IEnumerable<ExpenseItem> GetAllLessThan(decimal amount);
        IEnumerable<ExpenseItem> GetAllInRange(decimal min, decimal max);

        // Filtering by description
        IEnumerable<ExpenseItem> GetAllByDescription(string pattern);

        // Filtering by comment
        IEnumerable<ExpenseItem> GetAllByComment(string pattern);
    }
}
