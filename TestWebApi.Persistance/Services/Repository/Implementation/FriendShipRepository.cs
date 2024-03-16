using Microsoft.EntityFrameworkCore;
using TestWebApi.Domain.Exceptions;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Persistance.Services.Repository.Implementation
{
    public class FriendShipRepository : IFriendShipRepository
    {
        private readonly ApplicationContext _context;

        public FriendShipRepository(ApplicationContext context)
        {
            _context = context;
        }

        public async Task<bool> CheckToFriend(int user1Id, int user2Id)
        {
            var quary = _context.FriendShips
                .Where(f=> (f.UserFromId == user1Id && f.UserToId == user2Id) || (f.UserFromId == user2Id && f.UserToId == user1Id));

            quary = quary.Where(f=>f.Status == FriendShipStastus.InFrined);

            return await quary.AnyAsync();
        }

        public async Task CreateAsync(FriendShip entity)
        {
            if (entity is null)
                throw new ArgumentNullException(nameof(entity));

            await _context.FriendShips.AddAsync(entity);
            await _context.SaveChangesAsync();
            
        }

        public async Task DeleteAsync(int entityId)
        {
            var friendShip = await GetAsync(entityId);
            _context.FriendShips.Remove(friendShip);
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<FriendShip>> GetAllAsync()
        {
            return await _context.FriendShips.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<FriendShip>> GetAllRequestInFriendsAsync(int userId)
        {
            var quary =  _context.FriendShips.AsNoTracking();
            quary = quary.Where(f => f.UserToId == userId);
            quary = quary.Where(f=> f.Status == FriendShipStastus.WaitResponse);

            return await quary.ToListAsync();
        }

        public async Task<FriendShip> GetAsync(int entityId)
        {
            var friendShip = await _context.FriendShips
                .FirstOrDefaultAsync(f => f.Id == entityId);

            if (friendShip == null)
                throw new NotFoundEntityException("запрос в друзья не найден");

            return friendShip;
        }

        public async Task<FriendShip> GetNoTrackingAsync(int entityId)
        {
            var friendShip = await _context.FriendShips.AsNoTracking()
                .FirstOrDefaultAsync(f=>f.Id == entityId);

            if (friendShip == null)
                throw new NotFoundEntityException("запрос в друзья не найден");

            return friendShip;
        }

        public async Task UpdateAsync(FriendShip entity)
        {
            var oldDataFriendShip = await GetAsync(entity.Id);
            oldDataFriendShip.Status = entity.Status;
            await _context.SaveChangesAsync();

        }

        public async Task UpdateSatatusAsync(int friendShipId, FriendShipStastus stastus)
        {
            var friendShip = await GetAsync(friendShipId);
            friendShip.Status = stastus;
            await _context.SaveChangesAsync();
        }
    }
}
