using FluentValidation;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Services;
using FrogPay.Application.Shared.Notifications;
using FrogPay.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application
{
    public static class ServiceExtension
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddScoped<INotificationHandler, NotificationHandler>();

            services.AddScoped<IPessoaService, PessoaService>();

        }
    }
}
