using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application.Shared.Notifications
{
    public class NotificationHandler : INotificationHandler
    {
        private readonly List<Notification> _notifications = [];

        public IReadOnlyCollection<Notification> Notifications => _notifications.AsReadOnly();

        public bool HasNotifications => _notifications.Any();

        public void AddNotification(Notification notification)
        {
            _notifications.Add(notification);
        }
    }
}
