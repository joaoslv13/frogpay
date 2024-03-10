using FrogPay.Data.Context;
using FrogPay.Data.Repositories;
using FrogPay.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace FrogPay.Data
{
    public static class ServiceExtension
    {
        public static void ConfigureDataApp(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("Default");
            services.AddDbContext<AppDbContext>(opt => opt.UseNpgsql(connectionString));

            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IPessoaRepository, PessoaRepository>();
            services.AddScoped<ILojaRepository, LojaRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();

        }
    }
}
