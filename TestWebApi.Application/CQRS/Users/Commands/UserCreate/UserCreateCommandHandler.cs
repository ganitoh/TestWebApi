using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Users.Commands.UserCreate
{
    public class UserCreateCommandHandler 
        : IRequestHandler<UserCreateCommand,int>
    {
        private readonly IUserRepository _userRepositoty;

        public UserCreateCommandHandler(IUserRepository userRepositoty)
        {
            _userRepositoty = userRepositoty;
        }

        public async Task<int> Handle(
            UserCreateCommand request,
            CancellationToken cancellationToken)
        {
            var user = new User() { HashPassword = request.HashPassword, Login = request.Login };
            await _userRepositoty.CreateAsync(user);
            return user.Id;
        }
    }
}
