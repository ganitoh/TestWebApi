

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.Services.Abstarction
{
    public interface IPictureService
    {
        Task AddPictrue(PictureCreateCommand command);

        Task<IEnumerable<Picture>> GetPictureFriendAsync(int myId,int friendId);
    }
}
