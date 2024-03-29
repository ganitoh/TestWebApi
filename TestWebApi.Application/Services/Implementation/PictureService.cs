using TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser;
using TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate;
using TestWebApi.Application.Services.Abstarction;
using TestWebApi.Domain.Models;
using MediatR;

namespace TestWebApi.Application.Services.Implementation
{
    public class PictureService : IPictureService
    {
        private readonly IMediator _mediator;

        public PictureService(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task AddPictrue(Picture picture)
        {
            await _mediator.Send(new PictureCreateCommand(picture));
        }

        public async Task<IEnumerable<Picture>> GetPictureFriendAsync(int myId, int friendId)
        {
            return await _mediator.Send(new GetAllPicturesByFriendQuerie(myId, friendId));
        }
    }
}
