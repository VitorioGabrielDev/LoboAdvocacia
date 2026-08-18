using Flunt.Notifications;

namespace Lobo.Domain.SharedContext.Entities;

public abstract class Entity : Notifiable<Notification>
{
    public int Id { get; protected set; }
    public DateTime CreatedAt { get; } = default;
    public DateTime UpdatedAt { get; } = default;
}