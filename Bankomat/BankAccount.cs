namespace Bankomat
{
    public class BankAccount
    {
        public int AccountNumber { get; }
        public string Name { get; private set; } = "";
        public int Balance { get; private set; }

        public BankAccount(int accountNumber, string name, int balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            Name = name;
        }

        #region Account operations
        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Can not deposit a negative amount.");
            }

            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Can not withdraw a negative amount.");
            }
            if (Balance - amount < 0)
            {
                throw new Exception($"Not enough funds to withdraw {amount} SEK.");
            }

            Balance -= amount;
        }

        #endregion
    }
}
