using AffordIt.Application.SharedContext.UseCases;
using IuriDev26.Mediator.Abstractions;

namespace Lobo.Application.SharedContext.UseCases;

public abstract record Request<TResponse> : IRequest<Result<TResponse>>;