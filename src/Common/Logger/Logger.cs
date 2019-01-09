using System;
using System.Diagnostics;
using System.IO;

namespace Common.Logger
{
    public class Logger
    {
        private DateTime opened;
        private string path;
        private string now => DateTime.Now.ToString("o");
        public Logger()
        {
            opened = DateTime.Now;
            path = "file.log";
        }
        public Logger(string filepath)
        {
            opened = DateTime.Now;
            path = filepath;
        }
        public DateTime Opened { get => opened; }
        public string Path
        {
            get => path; set { if (path != value) path = value; }
        }
        public void FileWrite(object sender, LoggerEventArgs e)
        {
            string senderString = string.Empty;
            if (sender != null)
            {
                var notBlank = !string.IsNullOrWhiteSpace(sender.ToString());
                if (notBlank)
                {
                    senderString = $" [{(sender.ToString())}]";
                }
            }
            var lines = $"{now}{senderString}: {e.Message}";
            TextWriter textWriter = new StreamWriter(path, append: true);
            textWriter.WriteLineAsync(lines);
            textWriter.Close();
        }
        public void ConsoleWrite(object sender, LoggerEventArgs e)
        {
            Console.WriteLine(e.Message);
        }
        public void DebugWrite(object sender, LoggerEventArgs e)
        {
            Debug.WriteLine(e.Message);
        }
    }
}