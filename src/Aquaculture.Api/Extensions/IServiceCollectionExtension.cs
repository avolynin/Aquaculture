using Aquaculture.Api.Common.Mapping;
using Aquaculture.Api.Errors;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace Aquaculture.Api.Extensions;

public static class IServiceCollectionExtension
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, AquacultureProblemDetailsFactory>();
        services.AddMappings();
        return services;
    }
}
