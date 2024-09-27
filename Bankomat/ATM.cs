namespace Bankomat
{
    internal class ATM
    {
        private readonly Bank bank;

        public ATM(Bank bank)
        {
            this.bank = bank;
        }

        public void Run()
        {
            bool run = true;

            while (run)
            {
                MainMenu();

                switch (GetValidNumber())
                {
                    case 0:
                        MainMenu();
                        break;
                    case 1:
                        DepositMenu();
                        break;
                    case 2:
                        WithdrawMenu();
                        break;
                    case 3:
                        BalanceMenu();
                        break;
                    case 4:
                        ListMenu();
                        break;
                    case 5:
                        CreateAccountMenu();
                        break;
                    case 6:
                        RemoveAccountMenu();
                        break;
                    case 7:
                        ExitMenu();
                        run = false;
                        break;
                    default:
                        Console.Clear();
                        continue;
                }

                Console.Clear();
            }
        }

        #region Menu
        private void MainMenu()
        {
            Console.WriteLine("    Bankomat2000");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Deposit.");
            Console.WriteLine("2. Withdraw.");
            Console.WriteLine("3. Show balance.");
            Console.WriteLine("4. List all accounts.");
            Console.WriteLine("5. Create account.");
            Console.WriteLine("6. Delete account.");
            Console.WriteLine("7. Quit.");
        }

        private void DepositMenu()
        {
            Console.Clear();
            int accountNr = GetAccount();

            if (accountNr == -1)
            {
                return;
            }

            while (true)
            {
                var amount = GetValidNumber("Amount to deposit: ");

                try
                {
                    bank.Deposit(accountNr, amount);
                    Console.WriteLine($"{amount} SEK has been deposited into your account.");
                    Halt();
                    return;
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Halt();
                }
            }
        }

        private void WithdrawMenu()
        {
            Console.Clear();

            int accountNr = GetAccount();
            if (accountNr == -1)
            {
                return;
            }

            var amount = GetValidNumber("Amount to withdraw: ");

            try
            {
                bank.Withdraw(accountNr, amount);
                Console.WriteLine($"{amount} SEK has been withdrawn from your account.");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            Halt();
        }

        private void BalanceMenu()
        {
            Console.Clear();

            int accountNr = GetAccount();
            if (accountNr == -1)
            {
                return;
            }

            try
            {
                var balance = bank.GetBalance(accountNr);

                Console.WriteLine($"Your current balance is {balance} SEK.");
                Halt();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Halt();
            }
        }

        private void CreateAccountMenu()
        {
            Console.Clear();
            Console.WriteLine("Provide the following information to create the account.");
            Console.Write("Name of account holder: ");

            var name = Console.ReadLine();
            if (name == null)
            {
                Console.WriteLine("Invalid name");
                Halt();
                return;
            }

            var initialBalance = GetValidNumber("Initial balance of account: ");

            bank.CreateAccount(name, initialBalance);
        }

        private void RemoveAccountMenu()
        {
            Console.Clear();
            ListAccounts();

            var accountNumber = GetValidNumber("Input account number to remove: ");
            var exists = bank.AccountWithNumberExists(accountNumber);
            if (!exists)
            {
                Console.WriteLine("No account with that number exists.");
                Halt();
                return;
            }

            Console.WriteLine($"Are you sure you want to delete the account with account number {accountNumber}?");
            Console.WriteLine("Press (Y) to confirm");

            var key = Console.ReadKey();
            if (key.Key != ConsoleKey.Y)
            {
                return;
            }

            bank.DeleteAccount(accountNumber);
            Console.WriteLine("The account has been removed.");
            Halt();
        }

        private void ListMenu()
        {
            Console.Clear();
            ListAccounts();

            Halt();
        }

        private void ExitMenu()
        {
            bank.Save();

            Console.WriteLine("Thank you for using Bankomat2000.");
            Halt();
        }

        #endregion

        #region Helpers
        private static void Halt()
        {
            Console.WriteLine("Press the _ANY_ key to continue.");
            Console.ReadKey();
        }

        private int GetAccount()
        {
            if (bank.GetAccountList().Count == 0)
            {
                Console.WriteLine("No accounts available.");
                Halt();
                return -1;
            }

            while (true)
            {
                var accountNr = GetValidNumber("Input account number: ");
                if (bank.AccountWithNumberExists(accountNr))
                {
                    return accountNr;
                }
                else
                {
                    Console.WriteLine("Invalid account number, try again.");
                }
            }
        }

        private static int GetValidNumber(string message = "")
        {

            int input;
            while (true)
            {
                if (!string.IsNullOrEmpty(message))
                {
                    Console.Write(message);
                }

                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Invalid input, try again!");
                }
                else
                {
                    break;
                }
            }
            return input;
        }

        private void ListAccounts()
        {
            // Order by account number
            var accountList = bank.GetAccountList().OrderBy(acc => acc.AccountNumber).ToList();

            if (accountList.Count == 0)
            {
                Console.WriteLine("No accounts available.");
                return;
            }

            Console.WriteLine("---------------------------------------");
            Console.WriteLine("{0, -12}{1,-20}{2,-10}", "#", "Name", "Balance");
            Console.WriteLine("---------------------------------------");


            foreach (var account in accountList)
            {
                Console.WriteLine("{0, -12}{1,-20}{2,-10}", account.AccountNumber, account.Name, account.Balance);
            }

            Console.WriteLine("---------------------------------------");
        }
        #endregion
    }
}