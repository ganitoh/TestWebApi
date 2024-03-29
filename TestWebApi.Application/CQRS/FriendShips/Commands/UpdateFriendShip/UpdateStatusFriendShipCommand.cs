using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.FriendShips.Commands.UpdateFriendShip
{
    public class UpdateStatusFriendShipCommand : IRequest
    {
        public int FrendShipId { get; set; }
        public FriendShipStastus Status { get; set; }

        public UpdateStatusFriendShipCommand(int frendShipId, FriendShipStastus status)
        {
            FrendShipId = frendShipId;
            Status = status;
        }
    }
}
