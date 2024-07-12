namespace BankingSystem
{
    class BankingSystemMain
    {
        static List<AccountModel> accounts = new List<AccountModel>();
        static bool doRun = true;

        static void Main(string[] args)
        {
            string chosenAction;
            string? selectedAccountId = null;

            while (doRun)
            {
                Console.WriteLine("1. Add Account");
                if (selectedAccountId != null)
                {
                    Console.WriteLine("2. Deposit Money");
                    Console.WriteLine("3. Withdraw Money");
                    Console.WriteLine("4. Display Account Details");
                }
                Console.WriteLine("5. Exit");

                chosenAction = Console.ReadLine();

                switch (chosenAction)
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
                    Console.WriteLine($"Account Holder: {account.HolderName}");
                    Console.WriteLine($"Balance: {account.Balance}");
                    return;
                }
            }

            Console.WriteLine("Account not found.");
        }
    }
}
