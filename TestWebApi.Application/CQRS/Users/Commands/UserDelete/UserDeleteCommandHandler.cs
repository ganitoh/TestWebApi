using MediatR;
using TestWebApi.Persistance.Services.Repository.Abstraction;

namespace TestWebApi.Application.CQRS.Users.Commands.UserDelete
{
    public class UserDeleteCommandHandler
        : IRequestHandler<UserDeleteCommand>
    {
        private readonly IUserRepository _userRepository;

        public UserDeleteCommandHandler(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task Handle(
            UserDeleteCommand request,
            CancellationToken cancellationToken)
        {
            await _userRepository.DeleteAsync(request.userId);
        }
    }
}
