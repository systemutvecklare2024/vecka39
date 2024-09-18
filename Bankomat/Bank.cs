namespace Bankomat
{
    // Handles the business logic
    internal class Bank
    {
        BankAccount[] accounts;


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

        internal string[] AccountList()
        {
            string[] result = new string[accounts.Length];
            for (int i = 0; i < accounts.Length; i++)
            {
                result[i] = accounts[i].Display();
            }
            
            return result;
        }

        internal bool AccountWithNumberExists(int accountNr)
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

        internal bool Deposit(int accountNr, int amount)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    try
                    {
                        account.Deposit(amount);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ogiltigt belopp, försök igen.");
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }

        internal int GetBalance(int accountNr)
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

        internal bool Withdraw(int accountNr, int amount)
        {
            foreach (var account in accounts)
            {
                if (account.AccountNumber == accountNr)
                {
                    try
                    {
                        account.Withdraw(amount);
                    }
                    catch (Exception)
                    {
                        Console.WriteLine("Ogiltigt belopp, försök igen.");
                        return false;
                    }

                    return true;
                }
            }

            return false;
        }
    }
}
