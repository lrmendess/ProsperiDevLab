using System.Collections.Generic;

namespace ProsperiDevLab.Services.Notificator
{
    public interface INotificator
    {
        void Handle(Notification notification);
        bool HasNotifications();
        bool HasSuccess();
        bool HasWarnings();
        bool HasErrors();
        List<Notification> GetNotifications();
        List<Notification> GetSuccesses();
        List<Notification> GetWarnings();
        List<Notification> GetErrors();
    }
}
