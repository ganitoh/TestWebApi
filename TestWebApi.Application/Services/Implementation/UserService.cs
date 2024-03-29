using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.Domain.Models;
using TestWebApi.Domain.Exceptions;
using MediatR;
using TestWebApi.Application.CQRS.Users.Commands.UserCreate;
using TestWebApi.Application.CQRS.Users.Queries.GetUserByEmail;

namespace TestWebApi.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IHashPassword _hashPassword;
        private readonly IMediator _mediator;

        public UserService(
            IHashPassword hashPassword, 
            IMediator mediator)
        {
            _hashPassword = hashPassword;
            _mediator = mediator;
        }

        public async Task Register(User user, string password)
        {
            user.HashPassword = _hashPassword.HashPassword(password);
            int userId = await _mediator.Send(new UserCreateCommand(user.Login,user.HashPassword));
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _mediator.Send(new GetUserByLoginQuerie(login));

            if (_hashPassword.VerifyPassword(password, user.HashPassword))
                return user;

            throw new PasswordInccorectException("пароли не совпадают");
        }

    }
}
