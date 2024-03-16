
namespace TestWebApi.Domain.Exceptions
{
    public class NotFoundEntityException : Exception
    {
        public NotFoundEntityException(string message) 
            : base(message) { }
    }
}
