namespace Common.Exception
{
    public class YouLoseException : System.Exception
    {
        public YouLoseException() { }
        public YouLoseException(string message) : base(message) { }
        public YouLoseException(string message, System.Exception inner) : base(message, inner) { }
    }
}