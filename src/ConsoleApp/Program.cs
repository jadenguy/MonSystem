using System;
using System.Diagnostics;
using Common.Exception;
using Common.Logger;
using Common.Math;

namespace ConsoleApp
{
    class Program
    {
        private static object mainObject;
        private static Logger _logger = new Logger("file.log");
        static int Main()
        {
            SetUpGlobalExceptionHandlerAndLogging();
            Hack(10);
            return 0;
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            System.Console.WriteLine("GlobalExceptionHandler");
            try
            {
                var message = new LoggerEventArgs();
                message.Type = "GlobalExceptionHandler";
                Log(sender, message, "Exception detected");
                var ex = args as UnhandledExceptionEventArgs;
                if (ex != null)
                {
                    Log(sender, message, ex.ExceptionObject.ToString());
                }
                Log(sender, message, "Closing Unexpectedly");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine("GlobalExceptionHandlerFail");
                System.Console.WriteLine(ex);
                throw;
            }
            Environment.Exit(1);
        }
        private static void Log(object sender, LoggerEventArgs message, string text)
        {
            message.Message = text;
            Log(sender, message);
        }
        private static void SetUpGlobalExceptionHandlerAndLogging()
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += GlobalExceptionHandler;
            mainObject = "Program." + nameof(Main);
            _logger.WriteDebug = true;
            _logger.WriteConsole = true;
            _logger.WriteFile = true;
        }
        private static void Hack(int needed)
        {
            Log("Starting");
            Log("You attempt to hack the computer. Roll for initiative.");
            var Dice = new Dice(null);
            Dice.LoseEvent += ThrowException;
            var throwResult = Dice.SavingThrow(needed);
            Log(throwResult);
            Log("Closing");
        }
        private static void Log(string message) => _logger.LogThis(mainObject, message);
        private static void Log(object sender, LoggerEventArgs message) => _logger.LogThis(sender, message);
        static void ThrowException(object sender, string eventArgs) => throw new YouLoseException(eventArgs);
    }
}