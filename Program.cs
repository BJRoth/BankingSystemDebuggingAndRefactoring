using System;
using System.Collections.Generic;
using System.Security.Principal;

namespace BankingSystem
{
    class Program
    {
        static List<Account> accounts = new List<Account>();
        static bool doRun = true;

        static void Main(string[] args)
        {
            while (doRun)
            {
                Console.WriteLine("1. Add Account");
                if (accounts.Count > 0)
                {
                    Console.WriteLine("2. Deposit Money");
                    Console.WriteLine("3. Withdraw Money");
                    Console.WriteLine("4. Display Account Details");
                }
                Console.WriteLine("5. Exit");

                string choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        AddAccount();
                        break;
                    case "2":
                        DepositMoney();
                        break;
                    case "3":
                        WithdrawMoney();
                        break;
                    case "4":
                        DisplayAccountDetails();
                        break;
                    case "5":
                        doRun = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice.");
                        break;
                }
            }
        }

        static void AddAccount()
        {
            Console.WriteLine("Enter Account ID:");
            var id = Console.ReadLine();

            Console.WriteLine("Enter Account Holder Name:");
            var name = Console.ReadLine();

            Account account = new Account { Id = id, Name = name, Balance = 0 };
            accounts.Add(account);

            Console.WriteLine("Account added successfully.");
        }

        static void DepositMoney()
        {
            string id;
            double amount;

            Console.WriteLine("Enter Account ID:");
            id = Console.ReadLine();

            if (accounts.Any(a => a.Id == id))
            {
                Console.WriteLine("Enter Amount to Deposit:");

                if (double.TryParse(Console.ReadLine(), out amount))
                {
                    accounts.First(a => a.Id == id).Balance += amount;
                    Console.WriteLine("Deposit successful.");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please provide a numerical value.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void WithdrawMoney()
        {
            string id;
            double amount;

            Console.WriteLine("Enter Account ID:");
            id = Console.ReadLine();

            if (accounts.Any(a => a.Id == id))
            {
                Console.WriteLine("Enter Amount to Withdraw:");

                if (double.TryParse(Console.ReadLine(), out amount))
                {
                    if (accounts.First(a => a.Id == id).Balance >= amount)
                    {
                        accounts.First(a => a.Id == id).Balance -= amount;
                        Console.WriteLine("Withdrawal successful.");
                    }
                    else
                    {
                        Console.WriteLine("Insufficient balance.");
                    }
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please provide a numerical value.");
                }
            }
            else
            {
                Console.WriteLine("Account not found.");
            }
        }

        static void DisplayAccountDetails()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            foreach (var account in accounts)
            {
                if (account.Id == id)
                {
                    Console.WriteLine($"Account ID: {account.Id}");
                    Console.WriteLine($"Account Holder: {account.Name}");
                    Console.WriteLine($"Balance: {account.Balance}");
                    return;
                }
            }

            Console.WriteLine("Account not found.");
        }
    }

    class Account
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public double Balance { get; set; }
    }
}
