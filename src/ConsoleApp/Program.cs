using System;
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
            AppDomain.CurrentDomain.UnhandledException += GlobalExceptionHandler;
            System.Threading.Tasks.TaskScheduler.UnobservedTaskException += GlobalExceptionHandler;
            mainObject = nameof(Main);
            _logger.WriteFile = true;
            _logger.WriteConsole = true;
            _logger.WriteDebug = true;
            Log("Starting");
            Log("You attempt to hack the computer. Roll for initiative.");
            var Dice = new Dice(null);
            Dice.LoseEvent += ThrowException;
            var throwResult = Dice.SavingThrow(20);
            Log(throwResult);
            Log("Closing");
            return 0;
        }
        private static void Log(string message)
        {
            _logger.LogThis(mainObject, message);
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            try
            {
                System.Console.WriteLine("GlobalExceptionHandler");
                Log("Exception detected");
                Log(sender.ToString());
                Log(args.ToString());
                var ex = args as UnhandledExceptionEventArgs;
                if (ex != null)
                {
                    Log(ex.ExceptionObject.ToString());
                }
                Log("Closing Unexpectedly");
            }
            catch (System.Exception)
            {
                System.Console.WriteLine("GlobalExceptionHandlerFail");
            }
            finally
            {
                System.Console.WriteLine("GlobalExceptionHandlerDone");
                Environment.Exit(1);
            }
        }
        static void ThrowException(object sender, string eventArgs) => throw new Exception(eventArgs.ToString());
    }
}