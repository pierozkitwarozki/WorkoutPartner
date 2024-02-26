using System.Reflection;
using WorkoutPartner.Domain.ResultType;
using WorkoutPartner.Domain.ResultType.Errors;
using WorkoutPartner.Domain.ResultType.Errors.Codes;

namespace WorkoutPartner.Infrastructure.Extensions;

public static class ResultExtensions
{
    private static readonly string?[] ValidationErrorCodes = typeof(ValidationErrorCodes)
        .GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.FlattenHierarchy)
        .Where(field => field is { IsLiteral: true, IsInitOnly: false } && field.FieldType == typeof(string))
        .Select(field => (string)field.GetValue(null)!)
        .ToArray();

    public static bool IsValidationError(this Result result) 
        => result.Error is not null && ValidationErrorCodes.Contains(result.Error.Type);

    public static bool IsNotFound(this Result result)
        => result.Error is not null && result.Error.Type == nameof(NotFoundError);
}