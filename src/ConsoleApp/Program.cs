using System;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using Common.Logger;

namespace ConsoleApp
{
    partial class Program
    {
        private static object mainObject;
        public static event EventHandler<LoggerEventArgs> _logThis;
        public static Logger Log;
        public static event EventHandler<LoggerEventArgs> LogHandler

        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Combine(_logThis, value);
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Remove(_logThis, value);
        }
        static int Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            mainObject = "MainMethod";
            Log = new Logger("file.log");
            LogHandler += Log.FileWrite;
            LogHandler += Log.ConsoleWrite;
            LogHandler += Log.DebugWrite;
            LogThis(mainObject, "Starting");
            LogThis(mainObject, "You attempt to hack the computer. Roll for initiative.");
            var Dice = new Dice();
            LogThis(mainObject, Dice.SavingThrow(20));
            LogThis(mainObject, "Closing");
            return 0;
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            LogThis(mainObject, "Exception detected");
            LogThis(mainObject, sender.ToString());
            LogThis(mainObject, args.ToString());
            var ex = args as UnhandledExceptionEventArgs;
            if (ex != null)
            {
                LogThis(mainObject, ex.ExceptionObject.ToString());
            }
            LogThis(mainObject, "Closing Unexpectedly");
            Environment.Exit(1);
        }
        public static void LogThis(object sender, string logMessage)
        {
            EventHandler<LoggerEventArgs> logThis = _logThis as EventHandler<LoggerEventArgs>;
            var loggerEventArgs = new LoggerEventArgs(logMessage);
            if (logThis != null)
            {
                _logThis(sender, loggerEventArgs);
            }
        }
    }
}