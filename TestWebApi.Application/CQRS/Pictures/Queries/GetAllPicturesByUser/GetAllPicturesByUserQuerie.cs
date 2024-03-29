using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser
{
    public class GetAllPicturesByUserQuerie : IRequest<List<Picture>>
    {
        public int UserId { get; set; }

        public GetAllPicturesByUserQuerie(int userId)
        {
            UserId = userId;
        }
    }
}
