using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Pictures.Queries.GetAllPicturesByUser
{
    public class GetAllPicturesByUserQuerieHandler
        : IRequestHandler<GetAllPicturesByUserQuerie, List<Picture>>
    {

        private readonly IPictureRepository _picturerRepository;

        public GetAllPicturesByUserQuerieHandler(IPictureRepository picturerRepository)
        {
            _picturerRepository = picturerRepository;
        }

        public async Task<List<Picture>> Handle(
            GetAllPicturesByUserQuerie request, CancellationToken cancellationToken)
        {
            var result = await _picturerRepository.GetAllAsync(request.UserId);
            return result.ToList();
        }
    }
}
