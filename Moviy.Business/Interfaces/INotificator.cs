using Moviy.Business.Notifications;

namespace Moviy.Business.Interfaces
{
    public interface INotificator
    {
        bool HasNotification();

        List<Notification> GetNotifications();

        void Handle(Notification notification);


    }
}
