using FluentValidation;


namespace TestWebApi.Application.CQRS.Pictures.Commands.PictureCreate
{
    public class PictureCreateCommandValidtor : AbstractValidator<PictureCreateCommand>
    {
        public PictureCreateCommandValidtor()
        {
            RuleFor(p=>p.RelativePath).NotEmpty();
            RuleFor(p=>p.Description).MaximumLength(250);
            RuleFor(p => p.UserID).GreaterThan(0);
        }
    }
}
