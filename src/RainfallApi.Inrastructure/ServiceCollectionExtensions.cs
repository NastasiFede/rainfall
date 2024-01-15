using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RainfallApi.Infrastructure;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}