using Microsoft.EntityFrameworkCore;
using TestWebApi.Persistance.Services.Repository.Abstraction;
using TestWebApi.Domain.Exceptions;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Implementation
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _context;

        public UserRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task CreateAsync(User entity)
        {
            if(entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.Users.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int entityId)
        {
            var user = await GetAsync(entityId);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<User>> GetAllAsync() 
            => await _context.Users.AsNoTracking().ToListAsync();

        public async Task<User> GetAsync(int entityId)
        {
            var user = await _context.Users.SingleOrDefaultAsync(u => u.Id == entityId);

            if (user is null)
                throw new NotFoundEntityException("пользователь не найден");

            return user;
        }

        public async Task<User> GetByLogin(string login)
        {
            var user = await _context.Users.AsNoTracking().FirstOrDefaultAsync(u => u.Login == login);

            if (user is null)
                throw new NotFoundEntityException($"{login} не существует");

            return user;
        }

        public async Task<User> GetNoTrackingAsync(int entityId)
        {
            var user = await _context.Users.AsNoTracking()
                .SingleOrDefaultAsync(u => u.Id == entityId);

            if (user is null)
                throw new NotFoundEntityException("пользователь не найден");

            return user;
        }

        public async Task UpdateAsync(User entity)
        {
            var oldUserData = await GetAsync(entity.Id);

            oldUserData.Login = entity.Login;

            await _context.SaveChangesAsync();
        }
    }
}
