using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.CompilerServices;

namespace Common.Logger
{
    public class Logger
    {
        private DateTime opened = DateTime.Now;
        private event EventHandler<LoggerEventArgs> _logThis;
        public event EventHandler<LoggerEventArgs> LogEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Combine(_logThis, value);
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Remove(_logThis, value);
        }

        private string path = "file.log";
        private string now => DateTime.Now.ToString("o");
        public Logger() { }
        public Logger(string filepath)
        {
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
            var lines = $"{now}{senderString}: {e}";
            TextWriter textWriter = new StreamWriter(path, append: true);
            textWriter.WriteLineAsync(lines);
            textWriter.Close();
        }
        public void ConsoleWrite(object sender, LoggerEventArgs e)
        {
            Console.WriteLine(e);
        }
        public void DebugWrite(object sender, LoggerEventArgs e)
        {
            Debug.WriteLine(e);
        }
        public void LogThis(string logMessage)
        {
            LogThis(new object(), new LoggerEventArgs(logMessage));
        }
        public void LogThis(object sender, string logMessage)
        {
            LogThis(sender, new LoggerEventArgs(logMessage));
        }
        public void LogThis<T>(object sender, T eventArgs) where T : EventArgs
        {
            LogThis(sender, eventArgs.ToString());
        }
        public void LogThis(object sender, LoggerEventArgs eventArgs)
        {
            if (_logThis != null)
            {
                _logThis(sender, eventArgs);
            }
        }
    }
}