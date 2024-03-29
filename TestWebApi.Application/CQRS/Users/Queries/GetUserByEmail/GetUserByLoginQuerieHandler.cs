using MediatR;
using TestWebApi.Domain.Models;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Users.Queries.GetUserByEmail
{
    public class GetUserByLoginQuerieHandler 
        : IRequestHandler<GetUserByLoginQuerie, User>
    {
        readonly IUserRepository _userRepository;

        public GetUserByLoginQuerieHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<User> Handle(
            GetUserByLoginQuerie request, 
            CancellationToken cancellationToken)
        {
            var user = await _userRepository.GetByLogin(request.Email);
            return user;
        }
    }
}
