namespace Bankomat
{
    public class Bank
    {
        private readonly BankAccount[] accounts;

        public Bank()
        {
            accounts =
            [
                new BankAccount(1),
                new BankAccount(2),
                new BankAccount(3),
                new BankAccount(4),
                new BankAccount(5),
                new BankAccount(6),
                new BankAccount(7),
                new BankAccount(8),
                new BankAccount(9),
                new BankAccount(10),
            ];
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
            string[] result = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                result[i] = accounts[i].Display();
            }

            return result;
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
