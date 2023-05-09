using System.Text;
using Aquaculture.Application.Common;
using Aquaculture.Domain.Repositories;
using Aquaculture.Infrastructure.Authentication;
using Aquaculture.Infrastructure.Persistance.AquacultureContext;
using Aquaculture.Infrastructure.Persistance.ControlWaterContext;
using Aquaculture.Infrastructure.Persistance.DirectoryContext;
using Aquaculture.Infrastructure.Persistance.DirectoryContext.Repositories;
using Aquaculture.Infrastructure.Persistance.InfluenceWaterContext;
using Aquaculture.Infrastructure.Persistance.PersonalContext;
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
            .AddPersistance(configurationManager);

        services.AddSingleton<IDateTimeProvider, DateTimeProvider>();
        services.AddScoped<IPasswordHasher, PasswordHasher>();

        return services;
    }

    public static IServiceCollection AddPersistance(this IServiceCollection services, ConfigurationManager config)
    {
        services.AddDbContext<AquacultureDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddDbContext<WaterControlDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddDbContext<DirectoryDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddDbContext<InfluenceWaterDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));
        services.AddDbContext<PersonalDbContext>(options =>
            options.UseSqlServer(config.GetConnectionString("DefaultConnection")));

        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IPumpRepository, PumpRepository>();
        services.AddScoped<IDiseaseRepository, DiseaseRepository>();
        services.AddScoped<IMasterNetworkRepository, SensorRepository>();
        services.AddScoped<IWaterParamRepository, WaterParamRepository>();
        services.AddScoped<Domain.AquacultureContext.IFishTankRepository, Persistance.AquacultureContext.FishTankRepository>();
        services.AddScoped<Domain.InfluenceWaterContext.Repositories.IFishTankRepository, Persistance.InfluenceWaterContext.FishTankRepository>();
        services.AddScoped<IFishTypeRepository, FishTypeRepository>();
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
