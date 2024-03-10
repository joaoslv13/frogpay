using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace FrogPay.Application.Shared.Notifications
{
    public class Notification
    {
        public string Message { get; }

        [JsonIgnore]
        public NotificationLevel LevelId { get; }

        public string Level => LevelId.ToString();

        public Notification(string message, NotificationLevel level)
        {
            Message = message;
            LevelId = level;
        }
    }

    public enum NotificationLevel
    {
        Error,
        Warning,
        Info
    }
}
