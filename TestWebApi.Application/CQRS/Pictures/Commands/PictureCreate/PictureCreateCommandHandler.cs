using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate
{
    public class PictureCreateCommandHandler
        : IRequestHandler<PictureCreateCommand>
    {
        private readonly IPictureRepository _pictureRepository;

        public PictureCreateCommandHandler(IPictureRepository pictureRepository)
        {
            _pictureRepository = pictureRepository;
        }

        public async Task Handle(
            PictureCreateCommand request,
            CancellationToken cancellationToken)
        {

            await _pictureRepository.CreateAsync(
                new Picture()
                { Description = request.Description,
                    RelativePath = request.RelativePath,
                    UserID = request.UserID});
        }
    }
}
