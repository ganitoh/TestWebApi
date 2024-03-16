using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.Domain.Models;
using TestWebApi.Domain.Exceptions;

namespace TestWebApi.Application.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IHashPassword _hashPassword;

        public UserService(IUserRepository userRepository, IHashPassword hashPassword)
        {
            _userRepository = userRepository;
            _hashPassword = hashPassword;
        }

        public async Task Register(User user, string password)
        {
            user.HashPassword = _hashPassword.HashPassword(password);
            await _userRepository.CreateAsync(user);
        }

        public async Task<User> Login(string login, string password)
        {
            var user = await _userRepository.GetByLogin(login);

            if (_hashPassword.VerifyPassword(password, user.HashPassword))
                return user;

            throw new PasswordInccorectException("пароли не совпадают");
        }

    }
}
