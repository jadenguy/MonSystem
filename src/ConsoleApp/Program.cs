using System;

namespace ConsoleApp
{
    class Program
    {
        static int Main(string[] args)
        {
            AppDomain.CurrentDomain.UnhandledException += new UnhandledExceptionEventHandler(GlobalExceptionHandler);
            System.Console.WriteLine("Hello World!");
            return 0;
        }
        static void GlobalExceptionHandler(object sender, EventArgs args)
        {
            System.Console.WriteLine("Exception");
            Environment.Exit(1);
        }
    }
}