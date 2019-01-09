using System;

namespace Common.Logger
{
    public class LoggerEventArgs : EventArgs
    {
        public LoggerEventArgs(string message)
        {
            Message = message;
        }
        public string Message { get; set; }
    }
}