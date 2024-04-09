using FluentValidation;
using FluentValidation.Results;
using MediatR;


namespace TestWebApi.Application.CQRS
{
    public sealed class ValidationBehavior<TRequest, Tresponse>
        : IPipelineBehavior<TRequest, Tresponse>
        where TRequest : IRequest
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<Tresponse> Handle(TRequest request, RequestHandlerDelegate<Tresponse> next, CancellationToken cancellationToken)
        {
            var context = new ValidationContext<TRequest>(request);

            var validtionFailures = await Task.WhenAll(
                _validators.Select(validator=> validator.ValidateAsync(context)));

            var errors = validtionFailures
                .Where(validationResult => !validationResult.IsValid)
                .SelectMany(validationResult => validationResult.Errors)
                .Where(validationFailures => validtionFailures is not null)
                .ToList<ValidationFailure>();

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
        }
    }
}
