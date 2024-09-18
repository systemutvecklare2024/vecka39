namespace Bankomat
{
    // Handles user input and output
    internal class ATM
    {
        private Bank bank;

        public enum Menu
        {
            Main = 0,
            Deposit = 1,
            Withdraw = 2,
            Balance = 3,
            List = 4,
            Exit = 5
        }

        public ATM()
        {
            bank = new Bank();
        }

        public void Run()
        {
            var menuChoice = Menu.Main;
            bool run = true;

            while (run)
            {
                MainMenu();
                menuChoice = SelectChoice(GetInput());

                switch (menuChoice)
                {
                    case Menu.Main:
                        MainMenu();
                        break;
                    case Menu.Deposit:
                        DepositMenu();
                        break;
                    case Menu.Withdraw:
                        WithdrawMenu();
                        break;
                    case Menu.Balance:
                        BalanceMenu();
                        break;
                    case Menu.List:
                        ListMenu();
                        break;
                    case Menu.Exit:
                        ExitMenu();
                        run = false;
                        break;
                    default:
                        continue;
                }

                menuChoice = Menu.Main;

                Console.Clear();
            }
        }

        private void ListMenu()
        {
            Console.Clear();
            Console.WriteLine("----------------------");
            Console.WriteLine("Kontonr \tBalans");
            Console.WriteLine("----------------------");
            string[] accountList = bank.AccountList();
            for (int i = 0;i< accountList.Length;i++)
            {
                Console.WriteLine(accountList[i]);
            }
            Console.WriteLine("----------------------");

            Console.WriteLine("Tryck på valfri knapp för att fortsätta");
            Console.ReadKey();
        }

        private void MainMenu()
        {
            Console.WriteLine("    Bankomat2000");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Gör insättning.");
            Console.WriteLine("2. Gör uttag.");
            Console.WriteLine("3. Visa saldo.");
            Console.WriteLine("4. Lista alla konton.");
            Console.WriteLine("5. Avsluta.");
        }

        private void DepositMenu()
        {
            Console.Clear();
            int accountNr = GetAccount();

            while (true)
            {
                Console.Write("Summa att sätta in: ");
                var amount = GetInput();
                if (bank.Deposit(accountNr, amount))
                {
                    Console.WriteLine($"{amount} SEK har satts in på ert konto.");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Ett fel har inträffat, försök igen.");
                }
            }
        }

        private void WithdrawMenu()
        {
            Console.Clear();

            int accountNr = GetAccount();

            while (true)
            {

                Console.Write("Summa att ta ut: ");
                var amount = GetInput();


                if (bank.Withdraw(accountNr, amount))
                {
                    Console.WriteLine($"{amount} SEK har tagits ut från ert konto.");
                    Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                    Console.ReadKey();
                    return;
                }
                else
                {
                    Console.WriteLine("Ett fel har inträffat, försök igen.");
                }
            }
        }

        private void BalanceMenu()
        {
            Console.Clear();

            int accountNr = GetAccount();

            try
            {
                var balance = bank.GetBalance(accountNr);

                Console.WriteLine($"Det finns {balance} SEK på ert konto.");
                Console.WriteLine("Tryck på valfri knapp för att fortsätta");
                Console.ReadKey();
                return;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                Console.ReadKey();
            }
        }

        private void ExitMenu()
        {
            Console.WriteLine("Tack för att ni använder Bankomat2000");
            Console.WriteLine("Press the _any_ key to exit.");
            Console.ReadKey();
        }


        private int GetAccount()
        {
            while (true)
            {
                Console.Write("Ange kontonummer: ");
                var accountNr = GetInput();
                if (bank.AccountWithNumberExists(accountNr))
                {
                    return accountNr;
                }
                else
                {
                    Console.WriteLine("Ogiltigt kontonummer, försök igen.");
                }
            }
        }


        private Menu SelectChoice(int choice)
        {
            return (Menu)choice;
        }

        private int GetInput()
        {
            int input;
            while (true)
            {
                if (!int.TryParse(Console.ReadLine(), out input))
                {
                    Console.WriteLine("Ogiltig input, försök igen!");
                }
                else
                {
                    break;
                }
            }
            return input;
        }
    }
}