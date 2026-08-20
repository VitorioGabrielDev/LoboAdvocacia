using Flunt.Notifications;
using Lobo.Application.SharedContext.UseCases;

namespace Lobo.Application.SharedContext.Extensions;

public static class FluntExtensions
{
    extension(Notifiable<Notification> notifiable)
    {
        public List<Error> GetNotificationsAsErrors()
        {
            var errors = new List<Error>();
            notifiable.Notifications
                .ToList()
                .ForEach( notification => errors.Add(Error.ValidationError($"{notification.Key} - {notification.Message}")));
        
            return errors;
        }
    }
    
   
}