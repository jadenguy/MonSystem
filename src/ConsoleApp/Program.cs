using System;
using Common.Logger;
using Common.Math;

namespace ConsoleApp
{
    class Program
    {
        private static object mainObject = "program";

        private static Logger logger = new Logger("file.log");
        static int Main()
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            logger.LogEvent += logger.FileWrite;
            logger.LogEvent += logger.ConsoleWrite;
            logger.LogEvent += logger.DebugWrite;
            Log("Starting");
            Log("Starting");
            Log("You attempt to hack the computer. Roll for initiative.");
            var Dice = new Dice();
            Dice.LoseEvent += (o, e) => logger.LogThis(o,e);
            var throwResult = Dice.SavingThrow(20);
            Log(throwResult);
            Log("Closing");
            return 0;
        }

        private static void Log(string message)
        {
            logger.LogThis(mainObject, message);
        }

        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            Log("Exception detected");
            Log(sender.ToString());
            Log(args.ToString());
            var ex = args as UnhandledExceptionEventArgs;
            if (ex != null)
            {
                Log(ex.ExceptionObject.ToString());
            }
            Log("Closing Unexpectedly");
            Environment.Exit(1);
        }
    }
}