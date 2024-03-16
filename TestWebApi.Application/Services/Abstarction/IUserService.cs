using TestWebApi.Domain.Models;

namespace TestWebApi.Application.Services.Abstarction
{
    public interface IUserService
    {
        Task Register(User user, string password);
        Task<User> Login(string login, string password);
    }
}
