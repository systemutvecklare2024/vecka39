namespace Bankomat
{
    public class BankAccountDto
    {
        public int AccountNumber { get; set; }
        public int Balance { get; set; }

        public string Name { get; set; } = "";


        public BankAccount ToBankAccount()
        {
            return new BankAccount(AccountNumber, Name, Balance);
        }

        public static BankAccountDto FromBankAccount(BankAccount bankAccount)
        {
            return new BankAccountDto { 
                AccountNumber = bankAccount.AccountNumber, 
                Balance = bankAccount.Balance,
                Name = bankAccount.Name,
            };
        }
    }
}
