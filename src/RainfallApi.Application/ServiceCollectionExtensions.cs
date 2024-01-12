using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RainfallApi.Application.Services;

namespace RainfallApi.Application;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IRainfallManagementService, RainfallManagementService>();
        return services;
    }
}