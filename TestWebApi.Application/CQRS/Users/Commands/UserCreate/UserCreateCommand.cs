using MediatR;

namespace TestWebApi.Application.CQRS.Users.Commands.UserCreate
{
    public class UserCreateCommand : IRequest<int>
    {
        public string Login { get; set; } = string.Empty;
        public string HashPassword { get; set; } = string.Empty;

        public UserCreateCommand() { }
        public UserCreateCommand(string login, string hashPassword)
        {
            Login = login;
            HashPassword = hashPassword;
        }
    }
}
