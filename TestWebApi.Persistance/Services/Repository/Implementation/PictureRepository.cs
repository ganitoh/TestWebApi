using Microsoft.EntityFrameworkCore;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.Domain.Exceptions;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Implementation
{
    public class PictureRepository : IPictureRepository
    {
        private readonly ApplicationContext _context;

        public PictureRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(Picture entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Pictures.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var user = await GetAsync(entityId);
            _context.Pictures.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<Picture>> GetAllAsync()
            => await _context.Pictures.AsNoTracking().ToListAsync();

        public async Task<IEnumerable<Picture>> GetAllAsync(int userId)
            => await _context.Pictures.AsNoTracking().Where(p=>p.UserID == userId).ToListAsync();

        public async Task<Picture> GetAsync(int entityId)
        {
            var picture = await _context.Pictures
                .FirstOrDefaultAsync(p => p.Id == entityId);

            if (picture is null)
                throw new NotFoundEntityException("фотография не найдена");

            return picture;
        }

        public async Task<Picture> GetNoTrackingAsync(int entityId)
        {
            var user = await _context.Pictures.AsNoTracking()
                .FirstOrDefaultAsync(p=>p.Id == entityId);

            if (user is null)
                throw new NotFoundEntityException("фотография не найдена");

            return user;
        }

        public async Task UpdateAsync(Picture entity)
        {
            var userOldData = await GetAsync(entity.Id);
            userOldData.RelativePath = entity.RelativePath;
            await _context.SaveChangesAsync();
        }
    }
}
