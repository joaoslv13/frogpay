using FrogPay.Application.Shared.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Filters
{
    public class NotificationActionFilter : IActionFilter
    {
        private readonly INotificationHandler _notificationHandler;

        public NotificationActionFilter(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public void OnActionExecuting(ActionExecutingContext context) { }

        public void OnActionExecuted(ActionExecutedContext context)
        {
            if (_notificationHandler.HasNotifications)
            {
                context.Result = new BadRequestObjectResult(_notificationHandler.Notifications);
            }
        }
    }
}
