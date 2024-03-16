using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Domain.Exceptions;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IUserRepository _userRepository;
        private readonly IFriendShipRepository _friendShipRepository;

        public PictureService(
            IPictureRepository pictureRepository,
            IUserRepository userRepository,
            IFriendShipRepository friendShipRepository)
        {
            _pictureRepository = pictureRepository;
            _userRepository = userRepository;
            _friendShipRepository = friendShipRepository;
        }

        public async Task AddPictrue(Picture picture, int userId)
        {
            var user = await _userRepository.GetAsync(userId);
            picture.User = user;
            await _pictureRepository.CreateAsync(picture);
        }

        public async Task<IEnumerable<Picture>> GetPictureFriendAsync(int myId, int friendId)
        {
            if (await _friendShipRepository.CheckToFriend(myId, friendId))
                 return  await _pictureRepository.GetAllAsync(friendId);

            throw new NotFriendsException("нет в друзьях");
        }
    }
}
