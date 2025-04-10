using FluentValidation;
using MediatR;

namespace DynamicSortingImpl.Middlewares;

public class ValidationPipelineBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;

    public ValidationPipelineBehavior(IEnumerable<IValidator<TRequest>> validators)
    {
        this._validators = validators;
    }

    public Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        // var validationErrors = _validators
        //     .Select(validator => validator.Validate(request))
        //     .SelectMany(result => result.Errors)
        //     .Select(x => new 
        //     {
        //         SortBy = x.PropertyName,
        //         ErrorMessage = x.ErrorMessage,
        //         ErrorMessageCode = x.ErrorCode
        //     })
        //     .ToList();
        //
        // if (validationErrors.Any())
        // {
        //     throw new ValidationException(validationErrors.First().ErrorMessage);
        // }
        Console.WriteLine($"[ValidationPipelineBehavior]: {request.GetType().Name}");
        return next();
    }
}