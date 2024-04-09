using FluentValidation;


namespace TestWebApi.Application.CQRS.FriendShips.Commands.CreateFirenedShip
{
    public class CreaeteFrindShipCommandValidator : AbstractValidator<CreateFriendShipCommand>
    {
        public CreaeteFrindShipCommandValidator()
        {
            RuleFor(f => f.UserFromId).GreaterThan(0);
            RuleFor(f => f.UserToId).GreaterThan(0);
        }
    }
}
