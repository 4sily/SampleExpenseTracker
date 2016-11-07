using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExpenseTracker.Models
{
    public class ExpenseRepository : IExpenseRepository
    {
        private static ConcurrentDictionary<string, ExpenseItem> _expenses = new ConcurrentDictionary<string, ExpenseItem>();

        public ExpenseRepository()
        {
            Add(new ExpenseItem { Description = "Milk", Comment = "Vkusvill" });
        }

        public void Add(ExpenseItem item)
        {
            item.Key = Guid.NewGuid().ToString();
            _expenses[item.Key] = item;
        }

        public ExpenseItem Find(string key)
        {
            ExpenseItem item;
            _expenses.TryGetValue(key, out item);
            return item;
        }

        public IEnumerable<ExpenseItem> GetAll()
        {
            return _expenses.Values;
        }

        public IEnumerable<ExpenseItem> GetAllAfter(DateTime timePoint)
        {
            return GetAll().Where(_ => _.DateTime >= timePoint);
        }

        public IEnumerable<ExpenseItem> GetAllBefore(DateTime timePoint)
        {
            return GetAll().Where(_ => _.DateTime <= timePoint);
        }

        public IEnumerable<ExpenseItem> GetAllBetween(DateTime from, DateTime to)
        {
            return GetAll().Where(_ => _.DateTime >= from && _.DateTime <= to);
        }

        public IEnumerable<ExpenseItem> GetAllByComment(string pattern)
        {
            return GetAll().Where(_ => _.Comment.Contains(pattern));
        }

        public IEnumerable<ExpenseItem> GetAllByDescription(string pattern)
        {
            return GetAll().Where(_ => _.Description.Contains(pattern));
        }

        public IEnumerable<ExpenseItem> GetAllInRange(decimal min, decimal max)
        {
            return GetAll().Where(_ => _.Amount >= min && _.Amount <= max);
        }

        public IEnumerable<ExpenseItem> GetAllLessThan(decimal amount)
        {
            return GetAllInRange(0, amount);
        }

        public IEnumerable<ExpenseItem> GetAllMoreThan(decimal amount)
        {
            return GetAll().Where(_ => _.Amount >= amount);
        }

        public ExpenseItem Remove(string key)
        {
            ExpenseItem item;
            _expenses.TryRemove(key, out item);
            return item;
        }

        public void Update(ExpenseItem item)
        {
            _expenses[item.Key] = item;
        }
    }
}
