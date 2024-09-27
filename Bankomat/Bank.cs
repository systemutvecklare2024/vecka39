namespace Bankomat
{
    public class Bank
    {
        private readonly List<BankAccount> accounts;
        private readonly StorageManager storageManager;

        public Bank()
        {
            storageManager = new StorageManager("accounts.json");
            try
            {
                accounts = storageManager.Load();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        #region Account operations
        public void Withdraw(int accountNr, int amount)
        {
            try
            {
                var account = GetAccount(accountNr);
                account.Withdraw(amount);
                return;
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void Deposit(int accountNr, int amount)
        {
            try
            {
                var account = GetAccount(accountNr);
                account.Deposit(amount);
            }
            catch (Exception)
            {
                throw;
            }
        }

        public void CreateAccount(string name, int initialBalance=0)
        {
            var accountNr = GenerateValidId();
            var account = new BankAccount(accountNr, name, initialBalance);
            accounts.Add(account);
        }

        public void DeleteAccount(int accountId)
        {
            foreach (var account in accounts)
            {
                if(account.AccountNumber == accountId)
                {
                    if(!accounts.Remove(account))
                    {
                        throw new Exception($"Unable to remove account with id: {accountId}.");
                    }
                    return;
                }
            }
        }
        
        public int GetBalance(int accountNr)
        {
            var account = GetAccount(accountNr);
            
            return account.Balance;
        }

        public List<BankAccountDto> GetAccountList()
        {
            var result = new List<BankAccountDto>();
            foreach (var account in accounts)
            {
                result.Add(BankAccountDto.FromBankAccount(account));
            }

            return result;
        }


        private BankAccount GetAccount(int accountNr)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    return account;
                }
            }

            throw new Exception("Unable to find back account.");
        }

        public bool AccountWithNumberExists(int accountNr)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    return true;
                }
            }

            return false;
        }

        #endregion
        #region Helpers
        private int GenerateValidId()
        {
            Random rnd = new Random();
            while (true)
            {
                var number = rnd.Next((accounts.Count + 1) * 2);

                var query = from account in accounts
                            where account.AccountNumber == number
                            select account;

                if (query?.Count() == 0)
                    return number;
            }

        }

        public void Save()
        {
            storageManager.Save(accounts);
        }
        #endregion
    }
}
