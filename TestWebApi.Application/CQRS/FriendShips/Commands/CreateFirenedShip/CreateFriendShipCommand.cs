using MediatR;
using TestWebApi.Domain.Models;


namespace TestWebApi.Application.CQRS.FriendShips.Commands.CreateFirenedShip
{
    public class CreateFriendShipCommand : IRequest
    {
        public int UserFromId { get; set; }
        public int UserToId { get; set; }

        public CreateFriendShipCommand(int userFromId, int userToId)
        {
            UserFromId = userFromId;
            UserToId = userToId;
        }
    }
}
