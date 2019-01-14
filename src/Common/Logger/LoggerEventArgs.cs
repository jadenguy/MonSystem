using System;

namespace Common.Logger
{
    public class LoggerEventArgs : EventArgs
    {
        public LoggerEventArgs(string message)
        {
            Message = message;
        }
        public LoggerEventArgs(string message, string type)
        {
            Message = message;
            Type = type;
        }

        public LoggerEventArgs()
        {
        }

        public string Message;
        public string Type;
        public override string ToString()
        {
            var ret = "";
            if (!string.IsNullOrWhiteSpace(Type))
            {
                ret += $"<{Type}> ";
            }
            ret += Message;
            return ret;
        }
    }
}