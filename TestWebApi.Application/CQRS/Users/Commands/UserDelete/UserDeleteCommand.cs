using MediatR;


namespace TestWebApi.Application.CQRS.Users.Commands.UserDelete
{
    public class UserDeleteCommand : IRequest
    {
        public int userId { get; set; }
    }
}
