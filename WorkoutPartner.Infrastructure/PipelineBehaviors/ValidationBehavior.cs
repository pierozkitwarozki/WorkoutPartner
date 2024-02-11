using FluentValidation;
using MediatR;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;

namespace WorkoutPartner.Infrastructure.PipelineBehaviors;

public sealed class ValidationBehavior<TRequest, TResponse>(IEnumerable<IValidator<TRequest>> validators)
    : IPipelineBehavior<TRequest, TResponse>
    where TResponse : Result
    where TRequest : notnull
{
    public async Task<TResponse> Handle(
        TRequest request,
        RequestHandlerDelegate<TResponse> next,
        CancellationToken cancellationToken)
    {
        var context = new ValidationContext<TRequest>(request);

        var validationFailures = await Task.WhenAll(
            validators.Select(validator => validator.ValidateAsync(context, cancellationToken)));

        var errors = validationFailures
            .Where(validationResult => !validationResult.IsValid)
            .SelectMany(validationResult => validationResult.Errors)
            .Select(validationFailure => validationFailure.ErrorMessage)
            .ToList();

        if (errors.Count != 0)
        {
            var failure = Result.Failure(ValidationError.New(errors));
            var castedFailure = CastType(failure);
            return castedFailure!;
        }

        var response = await next();

        return response;
    }

    private static TResponse? CastType(Result failure)
    {
        var responseType = typeof(TResponse);

        if (!responseType.IsGenericType)
        {
            return failure as TResponse;
        }
        var resultType = responseType.GetGenericArguments()[0];
        var response = typeof(Result<>).MakeGenericType(resultType);
        var casted = Activator.CreateInstance(response, failure.Error, null) as TResponse;
        return casted;
    }
}