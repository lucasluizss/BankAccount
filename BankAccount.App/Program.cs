using System;
using BankAccount.Core.Entities;

namespace BankAccount.App
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("==> Welcome to Bank Account!");
            Console.Write("==> Enter with your name: ");
            var name = Console.ReadLine();

            var option = StartScreen(name);
            var amount = 0M;
            var account = new Account(() => { });

            while (option != 3)
            {
                switch (option)
                {
                    case 1:
                        amount = DepositScreen(name);
                        account.Deposit(amount);
                        break;
                    case 2:
                        amount = WithdrawScreen(name);
                        account.Withdraw(amount);
                        break;
                    default:
                        Console.Write("==> Invalid Option! Press any key to continue...");
                        Console.ReadKey();
                        break;
                }

                option = StartScreen(name, account.GetBalance());
            }

            Console.Write("\n\nPress any key to exit...");
            Console.ReadKey();
        }

        static int StartScreen(string name, decimal currentBalance = 0)
        {
            Console.Clear();
            Console.WriteLine($"\n====>\t\t{name}'s account.\t\t<====");
            Console.WriteLine(("").PadRight(53, '-'));
            Console.WriteLine($"==> Current balance:.........................[{currentBalance:C}]");
            Console.WriteLine($"==> Deposit..................................(1)");
            Console.WriteLine($"==> Withdraw.................................(2)");
            Console.WriteLine($"==> Exit.....................................(3)");

            Console.Write("\n==> Choose an option: ");
            return int.Parse(Console.ReadLine());
        }

        private static decimal DepositScreen(string name)
        {
            Console.Clear();
            Console.WriteLine($"\n====>\t Deposit in {name}'s account.\t<====");
            Console.WriteLine(("").PadRight(53, '-'));
            Console.Write($"==> Ammount: R$");
            return decimal.Parse(Console.ReadLine());
        }

        private static decimal WithdrawScreen(string name)
        {
            Console.Clear();
            Console.WriteLine($"\n====>\t Withdraw in {name}'s account.\t<====");
            Console.WriteLine(("").PadRight(53, '-'));
            Console.Write($"==> Ammount: R$");
            return decimal.Parse(Console.ReadLine());
        }
    }
}
