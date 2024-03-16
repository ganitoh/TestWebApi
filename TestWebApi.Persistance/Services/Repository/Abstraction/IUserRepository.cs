
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Abstraction
{
    public interface IUserRepository : IRepository<User> 
    { 
        Task<User> GetByLogin(string login);
    }
}
