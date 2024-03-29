using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.FriendShips.Commands.CreateFirenedShip
{
    public class CreateFriendShipCommandHandler
        : IRequestHandler<CreateFriendShipCommand>
    {
        private readonly IFriendShipRepository _friendShipRepository;

        public CreateFriendShipCommandHandler(IFriendShipRepository friendShipRepository)
        {
            _friendShipRepository = friendShipRepository;
        }

        public async Task Handle(
            CreateFriendShipCommand request, CancellationToken cancellationToken)
        {
            FriendShip friendShip = new FriendShip()
            {
                UserFromId = request.UserFromId,
                UserToId = request.UserToId,
                Status = FriendShipStastus.WaitResponse
            };

            await _friendShipRepository.CreateAsync(friendShip);
        }
    }
}
