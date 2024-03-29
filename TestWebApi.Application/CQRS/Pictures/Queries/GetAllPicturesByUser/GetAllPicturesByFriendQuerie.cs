using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser
{
    public class GetAllPicturesByFriendQuerie : IRequest<List<Picture>>
    {
        public int MyId { get; set; }
        public int FriendId { get; set; }

        public GetAllPicturesByFriendQuerie(int myId, int friendId)
        {
            MyId = myId;
            FriendId = friendId;
        }
    }
}
