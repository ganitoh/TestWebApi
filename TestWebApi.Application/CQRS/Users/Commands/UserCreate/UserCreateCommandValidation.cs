using FluentValidation;


namespace TestWebApi.Application.CQRS.Users.Commands.UserCreate
{
    public class UserCreateCommandValidation 
        : AbstractValidator<UserCreateCommand>
    {
        public UserCreateCommandValidation()
        {
            RuleFor(u => u.HashPassword).NotEmpty();
            RuleFor(u=>u.Login).NotEmpty().MaximumLength(50).MinimumLength(3);
        }
    }
}
