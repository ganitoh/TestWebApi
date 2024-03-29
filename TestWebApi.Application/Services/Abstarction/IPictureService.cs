

using Microsoft.EntityFrameworkCore.Metadata.Conventions;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.Services.Abstarction
{
    public interface IPictureService
    {
        Task AddPictrue(Picture picture);

        Task<IEnumerable<Picture>> GetPictureFriendAsync(int myId,int friendId);
    }
}
