using MediatR;
using TestWebApi.Domain.Models;

namespace TestWebApi.Application.CQRS.Users.Queries.GetUserByEmail
{
    public class GetUserByLoginQuerie : IRequest<User>
    {
        public string Email { get; set; } = null!;

        public GetUserByLoginQuerie(string email)
        {
            Email = email;
        }
    }
}
