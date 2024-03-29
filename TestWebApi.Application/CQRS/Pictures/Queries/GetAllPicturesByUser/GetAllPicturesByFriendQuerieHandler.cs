using Azure.Core;
using MediatR;
using TestWebApi.Domain.Exceptions;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser
{
    public class GetAllPicturesByFriendQuerieHandler
        : IRequestHandler<GetAllPicturesByFriendQuerie, List<Picture>>
    {
        private readonly IPictureRepository _pictureRepository;
        private readonly IFriendShipRepository _friendShipRepository;

        public GetAllPicturesByFriendQuerieHandler(
            IPictureRepository pictureRepository,
            IFriendShipRepository friendShipRepository)
        {
            _pictureRepository = pictureRepository;
            _friendShipRepository = friendShipRepository;
        }

        public async Task<List<Picture>> Handle(
            GetAllPicturesByFriendQuerie request, CancellationToken cancellationToken)
        {
            if (await _friendShipRepository.CheckToFriend(request.MyId, request.FriendId))
            {
                var result = await _pictureRepository.GetAllAsync(request.FriendId);
                return result.ToList();
            }

            throw new NotFriendsException("нет в друзьях");
        }
    }
}
