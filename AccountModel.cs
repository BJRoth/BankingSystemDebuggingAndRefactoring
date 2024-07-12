using BankingData;

namespace BankingSystem
{
    class AccountModel
    {
        public AccountModel()
        {
            
        }

        public AccountModel(Account account)
        {
            Id = account.Id;
            HolderName = account.HolderName;
            Balance = account.Balance;
        }

        public string Id { get; set; }
        public string HolderName { get; set; }
        public double Balance { get; set; }
    }
}
