namespace Lobo.Application.SharedContext.UseCases;

public class Result<T> : Result
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public List<Error> Errors { get; } = [];
    
    public Result() { }
    
    public Result(T data)
    {
        Data = data;
        IsSuccess = true;
    }

    public Result(List<Error> errors)
    {
        IsSuccess = false;
        Errors = errors;
    }

    public Result(Error error)
    {
        IsSuccess = false;
        Errors.Add(error);
    }
    
    public void SetData(T? data)
    {
        IsSuccess = data != null;
        Data = data;
    }
    
    public void AddError(string error) => Errors.Add(Error.ValidationError(error));
    
    public static Result<T> Failure(Error error) => new (error);
    public static Result<T> Failure(List<Error> errors) => new (errors);
    public static Result<T> BusinessRuleViolation(string message) => new(Error.BusinessRule(message));
    public static Result<T> ValidationError(string message) => new(Error.ValidationError(message));
    public static Result<T> InternalError(string message) => new(Error.InternalError(message));

}

public class Result
{
    public static Result<T> Success<T>(T data) => new (data);
}