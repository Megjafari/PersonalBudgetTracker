using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonalBudgetTracker
{
    public class BudgetManager
    {
        private List<Transaction> transactions = new();     //Lista som sparar alla transaktioner

        public void Run()
        {
            bool running = true;
            while (running)         //Huvudmeny loop som visar menyn och tar emot användarens val
            {           //Så länge running är true kommer loopen att fortsätta alltså så länge användaren inte väljer att avsluta programmet
                Console.WriteLine("\n==== Personal Budget Tracker ====");
                Console.WriteLine("1. Add Transaction");
                Console.WriteLine("2. View Transactions");
                Console.WriteLine("3. View Total Balance");
                Console.WriteLine("4. Remove Transactions");
                Console.WriteLine("5. Exit");

                Console.Write("Choose an option: ");

                switch (Console.ReadLine())
                {
                    case "1": AddTransactionFlow(); break;      //Anropar metoden för att lägga till en transaktion
                    case "2": ShowAll(); break;                 //visar alla transaktioner
                    case "3": ShowBalance(); break;             //visar den totala balansen
                    case "4": DeleteTransactionFlow(); break;   //tar bort en transaktion baserat på index
                    case "5": running = false; break;               //avslutar programmet
                    default: Console.WriteLine("Invalid choice!"); break;   //hanterar ogiltiga val
                }
            }
        }
        private void AddTransactionFlow()           //Metod för att lägga till en transaktion
        {
            Console.Write("Enter description: ");
            string des = Console.ReadLine();

            Console.Write("Enter amount (use negative for expenses and positive for income): ");
            if (!decimal.TryParse(Console.ReadLine(), out decimal amount))
            {
                Console.WriteLine("Invalid amount!");
                return;         //Avslutar metoden om inmatningen är ogiltig
            }

            Console.Write("Category: ");
            string category = Console.ReadLine();

            Console.Write("Date (YYYY-MM-DD): ");
            string date = Console.ReadLine();
                                                                                                                    //Lägger till den nya transaktionen i listan
            transactions.Add(new Transaction(date: DateTime.Parse(date), description: des, amount: amount, category: category));
            Console.WriteLine("Transaction added!");

        }
        private void ShowAll()              //Metod för att visa alla transaktioner
        {
            if (transactions.Count == 0)
            {
                Console.WriteLine("No transactions recorded.");
                return;
            }
            Console.WriteLine("\n--- All Transactions ---");
            for (int i = 0; i < transactions.Count; i++)
            {
                Console.Write($"{i,2}. ");          //Visar indexet för varje transaktion för att kunna ta bort senare
                transactions[i].Showinfo();         //Anropar Showinfo metoden som skriver ut transaktionsdetaljerna
            }
        }
        private void ShowBalance()          //Metod för att visa den totala balansen
        {
            decimal total = transactions.Sum(t => t.Amount);        //summerar alla transaktioners belopp
            Console.WriteLine($"\nTotal Balance: {total:0.00} kr");
        }
        private void DeleteTransactionFlow()        //Metod för att ta bort en transaktion baserat på index
        {
            ShowAll();
            Console.Write("Enter the index of the transaction to remove: ");
            if (int.TryParse(Console.ReadLine(), out int i) && i >= 0 && i < transactions.Count)
            {
                transactions.RemoveAt(i);           //Tar bort transaktionen vid det angivna indexet
                Console.WriteLine("Transaction removed.");
            }
            else
            {
                Console.WriteLine("Invalid index!");            //Hanterar ogiltiga index
            }


        }
    }
}
