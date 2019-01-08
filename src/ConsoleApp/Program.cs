using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Common.Logger;

namespace ConsoleApp
{
    partial class Program
    {
        // public static event LoggerHandler Log;
        private static LoggerHandler _log;
        public static event LoggerHandler LogHandler
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add
            {
                _log = (LoggerHandler)Delegate.Combine(_log, value);
            }
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove
            {
                _log = (LoggerHandler)Delegate.Remove(_log, value);
            }
        }
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            System.Console.WriteLine("You attempt to hack the computer. Roll for initiative.");
            var logger = new Logger();
            LogHandler += new LoggerHandler(logger.FileWrite);
            LogHandler += new LoggerHandler(logger.ConsoleWrite);
            SavingThrow(10);
            return 0;
        }
        private static void SavingThrow(int needed)
        {
            var dice = new Random();
            var diceRoll = dice.Next(20) + 1;
            System.Console.WriteLine($"You roll a {diceRoll}");
            if (diceRoll < needed)
            {
                var ex = new YouLoseException("You die");
                throw ex;
            }
            else
            {
                System.Console.WriteLine("You win the saving throw");
            }
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            LogThis("Exception detected");
            LogThis(sender.ToString());
            LogThis(args.ToString());
            var ex = args;
            Environment.Exit(1);
        }
        public static void LogThis(string logMessage)
        {
            LoggerHandler logThis = _log as LoggerHandler;
            if (logThis != null)
            {
                logThis(logMessage);
            }
        }
    }
}