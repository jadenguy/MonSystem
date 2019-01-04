using System;

namespace ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            System.Console.WriteLine("Hello World!");
            SavingThrow();

            return 0;
        }

        private static void SavingThrow()
        {
            var x = new Random();
            var diceRoll = x.Next(20) + 1;
            System.Console.WriteLine(diceRoll);
            if (diceRoll <= 19)
            {
                var ex = new System.Exception("You die");
                throw ex;
            }
            else
            {
                System.Console.WriteLine("You win the saving throw");
            }
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            System.Console.WriteLine("Exception detected");
            System.Console.WriteLine(sender);
            System.Console.WriteLine(args);
            Environment.Exit(1);
        }
    }
}