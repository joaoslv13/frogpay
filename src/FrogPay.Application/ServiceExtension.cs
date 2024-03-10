using FrogPay.Application.Interfaces;
using FrogPay.Application.Services;
using FrogPay.Domain.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FrogPay.Application
{
    public static class ServiceExtension
    {
        public static void ConfigureApplicationApp(this IServiceCollection services)
        {
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        }
    }
}
