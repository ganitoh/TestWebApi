using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate
{
    public class PictureCreateCommand : IRequest
    {
        public Picture Picture { get; set; }

        public PictureCreateCommand(Picture picture)
        {
            Picture = picture;
        }
    }
}
