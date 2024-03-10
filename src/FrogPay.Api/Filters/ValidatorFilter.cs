using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FrogPay.Api.Filters
{
    public class ValidatorFilter : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext context)
        {
            var services = context.HttpContext.RequestServices;
            foreach (var argument in context.ActionArguments.Values)
            {
                var validatorType = typeof(IValidator<>).MakeGenericType(argument!.GetType());
                var validator = services.GetService(validatorType) as IValidator;
                if (validator != null)
                {
                    var validationResult = validator.Validate(new ValidationContext<object>(argument));
                    if (!validationResult.IsValid)
                    {
                        foreach (var failure in validationResult.Errors)
                        {
                            context.ModelState.AddModelError(failure.PropertyName, failure.ErrorMessage);
                        }
                    }
                }
            }
        }
    }
}
