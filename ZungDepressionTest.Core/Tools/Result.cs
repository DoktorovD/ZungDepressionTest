namespace ZungDepressionTest.Core.Tools;

public sealed class Result<T>
{
    public bool IsFailure { get; init; }
    public bool IsOk { get; init; }
    public Error Error { get; init; }
    public T Value { get; init; }

    private Result(Error error)
    {
        Error = error;
        IsFailure = true;
        IsOk = false;
        Value = default!;
    }

    private Result(T value)
    {
        Value = value;
        IsOk = true;
        IsFailure = false;
        Error = Error.None;
    }

    public static Result<T> Ok(T value) => new Result<T>(value);

    public static Result<T> BadResult(Error error) => new Result<T>(error);

    public static implicit operator Result<T>(Error error) => new(error);

    public static implicit operator Result<T>(T value) => new(value);

    public static implicit operator T(Result<T> result) => result.Value;
}

public sealed record Error(string Message)
{
    public static readonly Error None = new Error(string.Empty);
}
