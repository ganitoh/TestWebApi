using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TestWebApi.Domain.Models;

namespace TestWebApi.Persistance.Services.Repository.Abstraction
{
    public interface IFriendShipRepository : IRepository<FriendShip> 
    {
        Task<IEnumerable<FriendShip>> GetAllRequestInFriendsAsync(int userId);
        Task UpdateSatatusAsync(int friendShipId ,FriendShipStastus stastus);
        Task<bool> CheckToFriend(int user1Id, int user2Id);
    }
}
