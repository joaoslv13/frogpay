using FrogPay.Application.Interfaces;
using FrogPay.Domain.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace FrogPay.Auth
{
    public static class ServiceExtension
    {
        public static void ConfigureAuth(this IServiceCollection services)
        {
            services.AddScoped<IAuthService, AuthService>();

            services.AddAuthentication(options =>
            {
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                var secretByte = Encoding.UTF8.GetBytes(AuthSettings.JwtSecret);
                var secretKey = new SymmetricSecurityKey(secretByte);

                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = secretKey,
                    ClockSkew = TimeSpan.FromMinutes(5)
                };

                options.Events = new JwtBearerEvents()
                {
                    OnMessageReceived = context =>
                    {
                        var token = context.Request.Query["access_token"];
                        context.Token ??= token;

                        return Task.CompletedTask;
                    }
                };
            });
        }
    }
}
