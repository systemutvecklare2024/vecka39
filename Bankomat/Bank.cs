namespace Bankomat
{
    public class Bank
    {
        private readonly List<BankAccount> accounts;

        public Bank()
        {
            accounts = new List<BankAccount>();
            SeedAccounts();
        }

        private void SeedAccounts()
        {
            for (int i = 0; i < 10; i++)
            {
                accounts.Add(new BankAccount(i));
            }
        }


        /************************
         * Account operations
         ************************/

        public bool Withdraw(int accountNr, int amount)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    return account.Withdraw(amount);
                }
            }

            return false;
        }
        public void Deposit(int accountNr, int amount)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber != accountNr)
                {
                    continue;
                }
                if (!account.Deposit(amount))
                {
                    throw new Exception("Transaktion kunde ej slutföras, försök igen.");
                }
            }
        }
        public int GetBalance(int accountNr)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    return account.Balance;
                }
            }

            throw new Exception("Ett problem uppstod, försök igen");
        }

        public string[] GetAccountList()
        {
            List<string> result = new();
            foreach (var account in accounts)
            {
                result.Add(account.Display());
            }

            return [.. result];
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
    }
}
