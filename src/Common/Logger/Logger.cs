using System;

namespace Common.Logger
{
    public class Logger
    {
        private DateTime opened;
        private string path;

        public Logger()
        {
            opened = DateTime.Now;

        }
        public DateTime Opened { get => opened; }
        public string Path { get => path; set => path = value; }

        public void FileWrite(string message)
        {
            System.Diagnostics.Debug.WriteLine($"{now()}: {message}");
        }

        private string now()
        {
            return DateTime.Now.ToString("o");
        }

        public void ConsoleWrite(string message)
        {
            System.Console.WriteLine(message);
        }
    }
}