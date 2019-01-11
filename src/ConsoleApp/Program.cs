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
            Hack(21);
            return 0;
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            try
            {
                Log("Exception detected");
                Log(sender.ToString());
                Log(args.ToString());
                var ex = args as UnhandledExceptionEventArgs;
                if (ex != null)
                {
                    Debug.Assert(ex.ExceptionObject != null);
                    Log(ex.ExceptionObject.ToString());
                }
                Log("Closing Unexpectedly");
            }
            catch (System.Exception ex)
            {
                System.Console.WriteLine(ex);
                System.Console.WriteLine("GlobalExceptionHandlerFail");
            }
            System.Console.WriteLine("GlobalExceptionHandlerDone");
            Environment.Exit(1);
        }
        private static void SetUpGlobalExceptionHandlerAndLogging()
        {
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += GlobalExceptionHandler;
            mainObject = nameof(Main);
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
        static void ThrowException(object sender, string eventArgs) => throw new YouLoseException(eventArgs);
    }
}