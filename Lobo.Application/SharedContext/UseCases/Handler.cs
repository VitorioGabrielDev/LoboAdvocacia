using IuriDev26.Mediator.Abstractions;

namespace Lobo.Application.SharedContext.UseCases;

public abstract class HandlerAsync<TRequest, TResponse> : IHandler<TRequest, Result<TResponse>>
    where TRequest : Request<TResponse>
{
    public abstract Task<Result<TResponse>> HandleAsync(TRequest request,
        CancellationToken cancellationToken = new CancellationToken());
}