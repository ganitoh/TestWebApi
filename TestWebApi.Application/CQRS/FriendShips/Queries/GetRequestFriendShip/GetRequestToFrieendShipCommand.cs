using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.FriendShips.Queries.GetRequestFriendShip
{
    public class GetRequestToFrieendShipCommand : IRequest<List<FriendShip>>
    {
        public int UserId { get; set; }

        public GetRequestToFrieendShipCommand(int userId)
        {
            UserId = userId;
        }
    }
}
