namespace Bankomat
{
    internal class BankAccount
    {
        public int AccountNumber { get; }
        public int Balance { get; private set; }

    
        public BankAccount(int accountNumber, int balance = 0)
        {
            AccountNumber = accountNumber;
            Balance = balance;
        }

        public void Deposit(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Kan ej sätta in negativ summa");
            }

            Balance += amount;
        }

        public void Withdraw(int amount)
        {
            if (amount < 0)
            {
                throw new Exception("Kan ej ta ut negativ summa");
            }
            if (Balance - amount < 0)
            {
                throw new Exception($"Det saknas medel för att ta ut {amount} SEK");
            }

            Balance -= amount;
        }

        public string Display()
        {
            return $"{AccountNumber} \t\t{Balance} SEK";
        }
    }
}
