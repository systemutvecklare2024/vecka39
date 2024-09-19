namespace Bankomat
{
    internal class BankAccount
    {
        public int AccountNumber { get; }
        public int Balance { get; private set; }

        public BankAccount(int accountNumber)
        {
            AccountNumber = accountNumber;
        }

        public bool Deposit(int amount)
        {
            if (amount < 0)
            {
                return false;
            }
            Balance += amount;

            return true;
        }

        public bool Withdraw(int amount)
        {
            if (Balance - amount >= 0)
            {
                Balance -= amount;
                return true;
            }

            return false;
        }

        public string Display()
        {
            return $"{AccountNumber} \t\t{Balance} SEK";
        }
    }
}
