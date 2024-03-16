namespace TestWebApi.Domain.Exceptions
{
    public class NotFriendsException : Exception
    {
        public NotFriendsException(string message) 
            : base (message) { }
    }
}
