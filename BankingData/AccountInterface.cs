using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankingData
{
    public interface AccountInterface
    {
        /// <summary> 
        /// Add a new account to the database.
        /// </summary>
        /// <returns>null if the account is added successfully, or a reason for it not being added on a failure.</returns>
        string? Add(Account account);
        /// <summary> 
        /// Open an existing account from the database.
        /// </summary>
        /// <returns>True if account exists, false if it doesn't.</returns>
        bool Open(string id);
        void Deposit(string id, double amount);
        void Withdraw(string id, double amount);
        AccountDTO Details(string id);
    }
}
