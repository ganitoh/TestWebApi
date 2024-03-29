using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.FriendShips.Commands.UpdateFriendShip
{
    internal class UpdateStatusFriendShipCommandHander
        : IRequestHandler<UpdateStatusFriendShipCommand>
    {
        private readonly IFriendShipRepository _friendShipRepository;

        public UpdateStatusFriendShipCommandHander(IFriendShipRepository friendShipRepository)
        {
            _friendShipRepository = friendShipRepository;
        }

        public async Task Handle(
            UpdateStatusFriendShipCommand request, CancellationToken cancellationToken)
        {
            await _friendShipRepository.UpdateSatatusAsync(request.FrendShipId, request.Status);
        }
    }
}
