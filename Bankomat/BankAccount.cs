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
    }
}
