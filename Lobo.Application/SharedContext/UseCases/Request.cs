using Flunt.Notifications;
using IuriDev26.Mediator.Abstractions;

namespace Lobo.Application.SharedContext.UseCases;

public abstract class Request<TResponse> : Notifiable<Notification>, IRequest<Result<TResponse>>
{
    public abstract bool Validate();
}