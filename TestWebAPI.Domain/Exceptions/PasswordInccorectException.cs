namespace TestWebApi.Domain.Exceptions
{
    public class PasswordInccorectException : Exception
    {
        public PasswordInccorectException(string message) 
            : base (message){ }
    }
}
