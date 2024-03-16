using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Abstraction
{
    public interface IPictureRepository : IRepository<Picture>
    {
        Task<IEnumerable<Picture>> GetAllAsync(int userId);
    }

}
