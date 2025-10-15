using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetTracker
{
    public class Transaction
    {
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public DateTime Date { get; set; }
        public string Category { get; set; }

        public Transaction(string description, decimal amount, DateTime date, string category)
        {
            Description = description;
            Amount = amount;
            Date = date;
            Category = category;
        }
        public void Showinfo()
        {
            Console.ForegroundColor = Amount < 0 ? ConsoleColor.Red : ConsoleColor.Green;
            Console.WriteLine($"{Date.ToShortDateString()} - {Description}: {Amount:C} [{Category}]");
            Console.ResetColor();
        }
    }
}
