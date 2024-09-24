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
                accounts = new List<BankAccount>();
                Console.WriteLine("Something blew up");
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        /************************
         * Account operations
         ************************/

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

        public void CreateAccount()
        {

        }

        public void DeleteAccount()
        {

        }
        

        public int GetBalance(int accountNr)
        {
            var account = GetAccount(accountNr);
            
            return account.Balance;
        }

        public string[] GetAccountList()
        {
            List<string> result = [];
            foreach (var account in accounts)
            {
                result.Add(account.Display());
            }

            return [.. result];
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

            throw new Exception("Bankkonto finns ej.");
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

        public void Save()
        {
            storageManager.Save(accounts);
        }
    }
}
