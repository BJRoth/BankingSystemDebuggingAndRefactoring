using BankingData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingSystem
{
    static internal class AccountController
    {
        static private AccountInterface Accounts = new AccountData();



        static void AddAccount()
        {
            Console.WriteLine("Enter Account ID:");
            string id = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(id))
            {
                Console.WriteLine("Id cannot be left blank.");
                return;
            }

            if (accounts.Any(a => a.Id == id))
            {
                Console.WriteLine("An account with that id already exists.");
                return;
            }

            Console.WriteLine("Enter Account Holder Name:");
            string name = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(name))
            {
                Console.WriteLine("Name cannot be left blank.");
                return;
            }

            AccountModel account = new AccountModel { Id = id, HolderName = name, Balance = 0 };
            Accounts.Add(account);

            Console.WriteLine("Account added successfully.");
        }

        static void OpenAccountForManagement()
        {

        }

        static void DepositToOpenAccount()
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

        static void WithdrawFromOpenAccount()
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
                    Console.WriteLine($"Account Holder: {account.HolderName}");
                    Console.WriteLine($"Balance: {account.Balance}");
                    return;
                }
            }

            Console.WriteLine("Account not found.");
        }
    }
}
