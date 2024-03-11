using FluentValidation;
using FrogPay.Application.Interfaces;
using FrogPay.Application.Services;
using FrogPay.Application.Shared.Notifications;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

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
            services.AddScoped<ILojaService, LojaService>();
            services.AddScoped<IDadosBancariosService, DadosBancariosService>();

        }
    }
}
