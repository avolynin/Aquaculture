using System.Text;
using Aquaculture.Application.Common;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Authentication;
using Aquaculture.Infrastructure.Persistance.Repositories;
using Aquaculture.Infrastructure.Persistence;
using Aquaculture.Infrastructure.Persistence.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace Aquaculture.Infrastructure.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddInfrastructure(
        this IServiceCollection services,
        ConfigurationManager configurationManager)
    {
        services
            .AddAuth(configurationManager)
            .AddPersistance();

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services)
    {
        services.AddDbContext<AquacultureDbContext>(options =>
            options.UseSqlServer("Server=host.docker.internal;Database=Aquaculture;User ID=sa;Password=Pas_sw0rd2023;TrustServerCertificate=True;"));
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IFishTankRepository, FishTankRepository>();
        services.AddScoped<IFishInfoRepository, FishInfoRepository>();
        services.AddScoped<IWaterMeasurementRepository, WaterMeasurementRepository>();
        return services;
    }

    public static IServiceCollection AddAuth(
        this IServiceCollection services,
        ConfigurationManager configuration)
    {
        var jwtSettings = new JwtSettings();
        configuration.Bind(JwtSettings.SectionName, jwtSettings);

        services.AddSingleton(Options.Create(jwtSettings));
        services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

        services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
            .AddJwtBearer(options =>
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = jwtSettings.Issuer,

                ValidateAudience = true,
                ValidAudience = jwtSettings.Audience,

                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(jwtSettings.SecretKey)),

                ValidateLifetime = true,
            });

        return services;
    }
}
