using System.Text.Json.Serialization;

namespace Booking_Airline.Common.Results;

public abstract class ResultBase
{
    public bool IsSuccess { get; }

    public bool IsFailure => !IsSuccess;

    public string Description { get; }

    public List<string>? Errors { get; protected set; }

    protected ResultBase(bool isSuccess, string description, List<string>? errors)
    {
        if (isSuccess && errors?.Count > 0)
        {
            throw new ArgumentException("Invalid result", nameof(errors));
        }

        IsSuccess = isSuccess;
        Errors = errors ?? [];
        Description = description;
    }
}

public class Result<T> : ResultBase
{
    public T Data { get; }

    [JsonConstructor]
    private Result(T data, bool isSuccess, string description, List<string>? errors = null)
        : base(isSuccess, description, errors)
    {
        Data = data;
    }

    public static Result<T> Success(string message = ResponseMessages.Success) => new(default!, true, message);

    public static Result<T> Success(T data, string message = ResponseMessages.Success) => new(data, true, message);

    public static Result<T> Failure(string message) => new(default!, false, message);

    public static Result<T> Failure(string error, string message = ResponseMessages.Error)
        => new(default!, false, message, [error]);

    public static Result<T> Failure(List<string> errors, string message = ResponseMessages.Error)
        => new(default!, false, message, errors);
}

public class Result : ResultBase
{
    [JsonConstructor]
    private Result(bool isSuccess, string description, List<string>? errors = null)
        : base(isSuccess, description, errors) { }

    public static Result Success(string message = ResponseMessages.Success) => new(true, message);

    public static Result Failure(string message) => new(false, message);

    public static Result Failure(string error, string message = ResponseMessages.Error)
        => new(false, message, [error]);

    public static Result Failure(List<string> errors, string message = ResponseMessages.Error)
        => new(false, message, errors);
}
