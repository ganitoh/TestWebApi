using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.FriendShips.Queries.GetRequestFriendShip
{
    internal class GetRequestToFriendShipCommandHandler 
        : IRequestHandler<GetRequestToFrieendShipCommand, List<FriendShip>>
    {

        private readonly IFriendShipRepository _friendShipRepository;

        public GetRequestToFriendShipCommandHandler(IFriendShipRepository friendShipRepository)
        {
            _friendShipRepository = friendShipRepository;
        }

        public async Task<List<FriendShip>> Handle(
            GetRequestToFrieendShipCommand request, CancellationToken cancellationToken)
        {
            var friendShips = await _friendShipRepository.GetAllRequestInFriendsAsync(request.UserId);
            return friendShips.ToList();
        }
    }
}
