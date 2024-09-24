using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bankomat
{
    internal class BankAccountDto
    {
        public int AccountNumber { get; set; }
        public int Balance { get; set; }


        public BankAccount ToBankAccount()
        {
            return new BankAccount(AccountNumber, Balance);
        }

        public static BankAccountDto FromBankAccount(BankAccount bankAccount)
        {
            return new BankAccountDto { 
                AccountNumber = bankAccount.AccountNumber, 
                Balance = bankAccount.Balance
            };
        }
    }
}
