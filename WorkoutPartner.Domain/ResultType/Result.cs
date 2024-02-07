namespace WorkoutPartner.Domain.ResultType;

public class Result<T> where T : class
{
    public bool IsSuccess { get; init; }
    public bool IsFailure { get; init; }
    public ResultError? Error { get; init; }
    public T? Value { get; init; }

    private Result(bool isSuccess, ResultError? error, T? value)
    {
        IsSuccess = isSuccess;
        IsFailure = !isSuccess;
        Error = error;
        Value = value;
    }

    public static Result<T> Success(T? value = null) => new(true, null, value);
    public static Result<T> Failure(ResultError error) => new(false, error, null);
}