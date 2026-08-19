using Lobo.Application.SharedContext.UseCases;

namespace AffordIt.Application.SharedContext.UseCases;

public class Result<T>
{
    public bool IsSuccess { get; private set; }
    public T? Data { get; private set; }
    public List<Error> Errors { get; } = [];
    
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

    public static Result<T> Success(T data) => new (data);
    public static Result<T> Failure(Error error) => new (error);
    public static Result<T> Failure(List<Error> errors) => new (errors);

}