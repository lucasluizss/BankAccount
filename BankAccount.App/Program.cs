using System;
using BankAccount.Core.Entities;
using BankAccount.Core.Enums;

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

            while (option != Option.Exit)
            {
                switch (option)
                {
                    case Option.Deposit:
                        amount = OperationScreen(name, option);
                        account.Deposit(amount);
                        break;
                    case Option.Withdraw:
                        amount = OperationScreen(name, option);
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

        static Option StartScreen(string name, decimal currentBalance = 0)
        {
            Console.Clear();
            Console.WriteLine($"\n====>\t\t{name}'s account.\t\t<====");
            Console.WriteLine(("").PadRight(53, '-'));
            Console.WriteLine($"==> Current balance:.........................[{currentBalance:C}]");
            Console.WriteLine($"==> Deposit..................................({(int)Option.Deposit})");
            Console.WriteLine($"==> Withdraw.................................({(int)Option.Withdraw})");
            Console.WriteLine($"==> Exit.....................................({(int)Option.Exit})");

            Console.Write("\n==> Choose an option: ");

            return (Option)(int.TryParse(Console.ReadLine(), out var option) ? option : 999);
        }

        private static decimal OperationScreen(string name, Option option)
        {
            Console.Clear();
            Console.WriteLine($"\n====>\t {option.ToString()} in {name}'s account.\t<====");
            Console.WriteLine(("").PadRight(53, '-'));
            Console.Write($"==> Ammount: R$ ");
            return decimal.Parse(Console.ReadLine());
        }
    }
}
