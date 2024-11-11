namespace ZungDepressionTest.Core.Helpers;

public sealed class Result<T>
{
    public bool IsSuccess { get; init; }
    public T Value { get; init; }
    public bool IsFailure { get; init; }
    public Error Error { get; init; }

    private Result(Error error)
    {
        Error = error;
        IsSuccess = false;
        IsFailure = true;
        Value = default!;
    }

    private Result(T value)
    {
        Value = value;
        IsSuccess = true;
        IsFailure = false;
        Error = Error.None;
    }

    public static Result<T> Success(T value)
    {
        return new Result<T>(value);
    }

    public static Result<T> Failure(Error error)
    {
        return new Result<T>(error);
    }

    public static implicit operator Result<T>(Error error)
    {
        return Failure(error);
    }

    public static implicit operator Result<T>(T value)
    {
        return Success(value);
    }
}
