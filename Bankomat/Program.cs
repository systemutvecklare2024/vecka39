namespace Bankomat
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Bank bank = new Bank();
            ATM atm = new ATM(bank);
            atm.Run();
        }
    }
}
