using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                DisplayMenu(menuChoice);
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
                        break;
                    case Menu.Balance:
                        break;
                    case Menu.List:
                        break;
                    case Menu.Exit:
                        Console.WriteLine("Tack för att ni använder Bankomat2000");
                        Console.WriteLine("Press the _any_ key to exit.");
                        Console.ReadKey();
                        run = false;
                        break;
                    default:
                        continue;
                }

                menuChoice = Menu.Main;

                Console.Clear();
            }
        }

        public void DisplayMenu(Menu menu)
        {
            switch (menu)
            {
                case Menu.Main:
                    MainMenu();
                    break;
            }
        }

        public void MainMenu()
        {
            Console.WriteLine("    Bankomat2000");
            Console.WriteLine("-----------------------");
            Console.WriteLine("1. Gör insättning.");
            Console.WriteLine("2. Gör uttag.");
            Console.WriteLine("3. Visa saldo.");
            Console.WriteLine("4. Lista alla konton.");
            Console.WriteLine("5. Avsluta.");
        }

        public void DepositMenu()
        {
            Console.Clear();
            int accountNr;
            while (true)
            {
                Console.Write("Ange kontonummer: ");
                accountNr = GetInput();
                if (bank.AccountWithNumberExists(accountNr))
                {
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
                    }
                }
                else
                {
                    Console.WriteLine("Ogiltigt kontonummer, försök igen.");
                }
            }
        }

        public Menu SelectChoice(int choice)
        {
            return (Menu)choice;
        }

        public int GetInput()
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
