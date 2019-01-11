using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace Common.Logger
{
    public class Logger
    {
        private DateTime _opened = DateTime.Now;
        private const string _defaultFilePath = "file.log";
        private TextWriter _textWriter = new StreamWriter(_defaultFilePath, append: true);
        ~Logger()
        {
            _textWriter.Close();
        }
        public bool WriteFile
        {
            get => IsDelegateInEvent(new EventHandler<LoggerEventArgs>(FileWrite));
            set { if (value) { AddDelegateOnlyOnce(new EventHandler<LoggerEventArgs>(FileWrite)); } }
        }
        public bool WriteConsole
        {
            get => IsDelegateInEvent(new EventHandler<LoggerEventArgs>(ConsoleWrite));
            set { if (value) { AddDelegateOnlyOnce(new EventHandler<LoggerEventArgs>(ConsoleWrite)); } }
        }
        public bool WriteDebug
        {
            get => IsDelegateInEvent(new EventHandler<LoggerEventArgs>(DebugWrite));
            set
            {
                if (value) { AddDelegateOnlyOnce(new EventHandler<LoggerEventArgs>(DebugWrite)); }
            }
        }
        private void AddDelegateOnlyOnce(EventHandler<LoggerEventArgs> del)
        {
            if (!IsDelegateInEvent(del))
            {
                _logThis -= del;
                _logThis += del;
            }
        }
        private bool IsDelegateInEvent(EventHandler<LoggerEventArgs> del)
        {
            return _logThis?.GetInvocationList()?.
                                Where(d => d.Equals(del))?.
                                Count() > 0;
        }
        public event EventHandler<LoggerEventArgs> _logThis;
        private string path = _defaultFilePath;
        private string nowString => DateTime.Now.ToString("o");
        private Logger() { }
        public Logger(string filepath) => Path = filepath;
        private DateTime Opened { get => _opened; }
        private string Path
        {
            get => path;
            set
            {
                if (string.IsNullOrWhiteSpace(value) && path != value)
                {
                    path = value;
                    _textWriter.Close();
                    _textWriter = new StreamWriter(path, append: true);
                }
            }
        }
        
        private void FileWrite(object sender, LoggerEventArgs e)
        {
            string senderString = string.Empty;
            if (sender != null && !string.IsNullOrWhiteSpace(sender.ToString()))
            {
                senderString = $" [{(sender.ToString())}]";
            }
            var lines = $"{nowString}{senderString}: {e}";
            _textWriter.WriteLine(lines);
        }
        private void ConsoleWrite(object sender, LoggerEventArgs e) => Console.WriteLine(e);
        private string ReturnWrite(object sender, LoggerEventArgs e) => e.ToString();
        private void DebugWrite(object sender, LoggerEventArgs e) => Debug.WriteLine(e);
        public void LogThis(object sender, string logMessage) => LogThis(sender, new LoggerEventArgs(logMessage));
        private void LogThis(object sender, LoggerEventArgs loggerEventArgs) => _logThis?.Invoke(sender, loggerEventArgs);
    }
}