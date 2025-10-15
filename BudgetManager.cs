using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetTracker
{
    public class BudgetManager
    {
        private List<Transaction> transactions = new();

        public void Run()
        {
            bool running = true;
            while (running)
            {
                Console.WriteLine("\n==== Personal Budget Tracker ====");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. View Total Balance");
                Console.WriteLine("4. Remove Transactions");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddTransactionFlow(); break;
                    case "2": ShowAll(); break;
                    case "3": ShowBalance(); break;
                    case "4": DeleteTransactionFlow(); break;
                    case "5": running = false; break;
                    default: Console.WriteLine("Invalid choice!"); break;
                }
            }
        }
        private void AddTransactionFlow()
        {
            Console.Write("Enter description: ");
            string des = Console.ReadLine();

            Console.Write("Enter amount (use negative for expenses and positive for income): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount!");
                return;
            }

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Date (YYYY-MM-DD): ");
            string date = Console.ReadLine();

            transactions.Add(new Transaction(date: DateTime.Parse(date), description: des, amount: amount, category: category));
            Console.WriteLine("Transaction added!");

        }
        private void ShowAll()
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions recorded.");
                return;
            }
            Console.WriteLine("\n--- All Transactions ---");
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.Write($"{i,2}. ");
                transactions[i].Showinfo();
            }
        }
        private void ShowBalance()
        {
            decimal total = transactions.Sum(t => t.Amount);
            Console.WriteLine($"\nTotal Balance: {total:0.00} kr");
        }
        private void DeleteTransactionFlow()
        {
            ShowAll();
            Console.Write("Enter the index of the transaction to remove: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i >= 0 && i < transactions.Count)
            {
                transactions.RemoveAt(i);
                Console.WriteLine("Transaction removed.");
            }
            else
            {
                Console.WriteLine("Invalid index!");
            }


        }
    }
}
