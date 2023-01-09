using Core.Enums;

namespace Core.Dtos;

public class Result
{
    private List<string> _errors = new();

    protected Result()
    {

    }

    protected Result(IEnumerable<string> errors)
    {
        AddError(errors);
    }

    public bool IsSuccessful { get; protected set; } = true;

    public IReadOnlyCollection<string> Errors => _errors.AsReadOnly();

    public void AddError(params string[] codes)
    {
        AddErrorCore(codes);
    }

    public void AddError(IEnumerable<string> codes)
    {
        AddErrorCore(codes);
    }

    public void ResetIsErrorFlag()
    {
        IsSuccessful = true;
    }

    public static Result Success()
    {
        return new Result();
    }

    public static Result<T> Success<T>(T data)
    {
        return new Result<T>(data);
    }

    public static Result Error(params string[] codes)
    {
        return new Result(codes);
    }

    public static Result Error(IEnumerable<string> codes)
    {
        return new Result(codes);
    }

    public static Result UnknownError()
    {
        return Error("Something went wrong at the server. Please call support");
    }

    public static Result<T> Error<T>(params string[] codes)
    {
        return new Result<T>(codes);
    }

    public static Result<T> Error<T>(IEnumerable<string> codes)
    {
        return new Result<T>(codes);
    }

    public static Result<T> UnknownError<T>()
    {
        return Error<T>(ErrorCodes.UnknownError);
    }

    private void AddErrorCore(IEnumerable<string> codes)
    {
        _errors.AddRange(codes);
        IsSuccessful = false;
    }

}

public class Result<TData>: Result
{
    internal Result(TData data)
    {
        Data = data;
    }

    internal Result(IEnumerable<string> errors): base(errors)
    {
    }

    public TData? Data { get; protected set; }

}