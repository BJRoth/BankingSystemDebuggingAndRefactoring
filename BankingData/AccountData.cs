using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingData
{
    public class AccountData : AccountInterface
    {
        private BankingDatabaseContext db = new BankingDatabaseContext();

        public string? Add(Account account)
        {
            if (db.Accounts.Any(a => a.Id == account.Id))
            {
                return "An account with that id already exists.";
            }

            db.Accounts.Add(account);

            return null;
        }

        public bool Open(string id)
        {
            throw new NotImplementedException();
        }

        public void Deposit(string id, double amount)
        {
            throw new NotImplementedException();
        }

        public Account Details(string id)
        {
            throw new NotImplementedException();
        }

        public void Withdraw(string id, double amount)
        {
            throw new NotImplementedException();
        }
    }
}
