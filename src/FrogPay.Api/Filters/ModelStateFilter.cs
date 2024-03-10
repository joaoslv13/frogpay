using FrogPay.Application.Shared.Notifications;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.AspNetCore.Mvc;

namespace FrogPay.Api.Filters
{
    public class ModelStateFilter : IAsyncActionFilter
    {
        private readonly INotificationHandler _notificationHandler;

        public ModelStateFilter(INotificationHandler notificationHandler)
        {
            _notificationHandler = notificationHandler;
        }

        public async Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            if (!context.ModelState.IsValid)
            {
                var errors = context.ModelState
                    .Where(e => e.Value?.Errors.Count > 0)
                    .SelectMany(x => x.Value?.Errors!)
                    .Select(x => x.ErrorMessage);

                foreach (var error in errors)
                {
                    _notificationHandler.AddNotification(new Notification(error, NotificationLevel.Error));
                }

                context.Result = new BadRequestObjectResult(_notificationHandler.Notifications);
                return;
            }

            await next();
        }
    }
}
