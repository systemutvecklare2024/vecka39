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

        internal void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Invalid amount");
            }
            Balance += amount;
        }

        internal void Withdraw(int amount)
        {
            if ( Balance - amount >= 0)
            {
                Balance -= amount;
            } else
            {
                throw new Exception("Not enough money");
            }
        }

        internal string Display()
        {
            return $"{AccountNumber} \t\t{Balance} SEK";
        }
    }
}
