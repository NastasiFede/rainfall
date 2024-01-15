using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RainfallApi.Repository;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddPersistenceServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}