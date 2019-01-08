using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Common.Logger;

namespace ConsoleApp
{
    class Program
    {
        // private static LoggerHandler _log;
        public static event LoggerHandler logThis;
        // public static event LoggerHandler logThis
        // {
        //     [MethodImpl(MethodImplOptions.Synchronized)]
        //     add
        //     {
        //         _log = (LoggerHandler)Delegate.Combine(_log, value);
        //     }
        //     [MethodImpl(MethodImplOptions.Synchronized)]
        //     remove
        //     {
        //         _log = (LoggerHandler)Delegate.Remove(_log, value);
        //     }
        // }
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            System.Console.WriteLine("You attempt to hack the computer. Roll for initiative.");
            var logger = new Logger();
            logThis += new LoggerHandler(logger.FileWrite);
            logThis += new LoggerHandler(logger.ConsoleWrite);
            SavingThrow();
            return 0;
        }
        private static void SavingThrow()
        {
            var dice = new Random();
            var diceRoll = dice.Next(20) + 1;
            System.Console.WriteLine($"You roll a {diceRoll}");
            if (diceRoll <= 19)
            {
                var ex = new YouLoseException("You die");
                throw ex;
            }
            else
            {
                System.Console.WriteLine("You win the saving throw");
            }
        }
        public class YouLoseException : System.Exception
        {
            public YouLoseException() { }
            public YouLoseException(string message) : base(message) { }
            public YouLoseException(string message, System.Exception inner) : base(message, inner) { }
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            if (logThis != null)
            {
                logThis("Exception detected");
                logThis(sender.ToString());
                logThis(args.ToString());
            }
            var ex = args;
            Environment.Exit(1);
        }
    }
}