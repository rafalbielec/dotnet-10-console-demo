namespace Extra;

public enum ErrorCode { BrokenIntroFile };
public readonly record struct Error(ErrorCode code, string message = null);

public class ReferenceResult<T> where T : class
{
    public T Value { get; init; }
    public bool Success { get; init; }
    public Error Error { get; init; }

    public ReferenceResult(T value, bool success, Error error)
    {
        Value = value;
        Success = success;
        Error = error;
    }

    public static implicit operator ReferenceResult<T>(T value) => new(value, true, default);
    public static implicit operator ReferenceResult<T>(Error error) => new(null, false, error);
}
