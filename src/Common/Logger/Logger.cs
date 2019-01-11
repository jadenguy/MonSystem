using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Common.Logger
{
    public class Logger
    {
        private DateTime opened = DateTime.Now;

        public bool WriteFile
        {
            get => IsMethodInDelegate(new EventHandler<LoggerEventArgs>(FileWrite));

            set
            {
                var del = new EventHandler<LoggerEventArgs>(FileWrite);
                if (value)
                { AddDelegateOnlyOnce(del); }
            }
        }
        public bool WriteConsole
        {
            get => IsMethodInDelegate(new EventHandler<LoggerEventArgs>(ConsoleWrite));

            set
            {
                var del = new EventHandler<LoggerEventArgs>(ConsoleWrite);
                if (value)
                { AddDelegateOnlyOnce(del); }
            }
        }
        public bool WriteDebug
        {
            get => IsMethodInDelegate(new EventHandler<LoggerEventArgs>(DebugWrite));

            set
            {
                var del = new EventHandler<LoggerEventArgs>(DebugWrite);
                if (value)
                { AddDelegateOnlyOnce(del); }
            }
        }
        private void AddDelegateOnlyOnce(EventHandler<LoggerEventArgs> del)
        {
            if (!IsMethodInDelegate(del))
            {
                LogEvent -= del;
                LogEvent += del;
            }
        }
        private bool IsMethodInDelegate(EventHandler<LoggerEventArgs> del)
        {
            return _logThis?.GetInvocationList()?.
                                Where(d => d.Equals(del))?.
                                Count() > 0;
        }

        public event EventHandler<LoggerEventArgs> _logThis;
        private event EventHandler<LoggerEventArgs> LogEvent
        {
            [MethodImpl(MethodImplOptions.Synchronized)]
            add => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Combine(_logThis, value);
            [MethodImpl(MethodImplOptions.Synchronized)]
            remove => _logThis = (EventHandler<LoggerEventArgs>)Delegate.Remove(_logThis, value);
        }
        private string path = "file.log";
        private string nowString => DateTime.Now.ToString("o");
        private Logger() { }
        public Logger(string filepath)
        {
            path = filepath;
        }
        private DateTime Opened { get => opened; }
        private string Path
        {
            get => path; set { if (string.IsNullOrWhiteSpace(value) && path != value) path = value; }
        }
        private void FileWrite(object sender, LoggerEventArgs e)
        {
            string senderString = string.Empty;
            if (sender != null && !string.IsNullOrWhiteSpace(sender.ToString()))
            {
                senderString = $" [{(sender.ToString())}]";
            }
            var lines = $"{nowString}{senderString}: {e}";
            TextWriter textWriter = new StreamWriter(path, append: true);
            textWriter.WriteLineAsync(lines);
            textWriter.Close();
        }
        private void ConsoleWrite(object sender, LoggerEventArgs e)
        {
            Console.WriteLine(e);
        }
        private void DebugWrite(object sender, LoggerEventArgs e)
        {
            Debug.WriteLine(e);
        }
        public void LogThis(object sender, string logMessage)
        {
            LogThis(sender, new LoggerEventArgs(logMessage));
        }
        private void LogThis(object sender, LoggerEventArgs loggerEventArgs)
        {
            _logThis?.Invoke(sender, loggerEventArgs);
        }
    }
}