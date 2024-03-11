using FrogPay.Api.Extensions;
using FrogPay.Api.Filters;
using FrogPay.Application;
using FrogPay.Auth;
using FrogPay.Data;
using FrogPay.Data.Context;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers(options =>
{
    options.Filters.Add<ValidatorFilter>();
    options.Filters.Add<ModelStateFilter>();
    options.Filters.Add<NotificationActionFilter>();
});

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.ConfigureApplicationApp();
builder.Services.ConfigureDataApp(builder.Configuration);
builder.Services.ConfigureCorsPolicy();
builder.Services.ConfigureAuth();

builder.Services.Configure<JwtSettingsOptions>(
    builder.Configuration.GetRequiredSection(JwtSettingsOptions.SessionName));

builder.Services.AddSingleton(provider => provider.GetRequiredService<IOptions<JwtSettingsOptions>>().Value);

builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc("v1", new OpenApiInfo { Title = "My API", Version = "v1" });

    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "Autenticação JWT usando o esquema Bearer. Exemplo: \"Authorization: Bearer { token }\"",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer"
    });

    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "Bearer"
                },
                Scheme = "oauth2",
                Name = "Bearer",
                In = ParameterLocation.Header,
            },
            new List<string>()
        }
    });
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    using (var scope = app.Services.CreateScope())
    {
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<AppDbContext>();
            context.Database.Migrate();

            await AppDbContextSeed.SeedAsync(context);
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}

app.UseSwagger();
app.UseSwaggerUI();


//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
