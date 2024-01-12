using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace RainfallApi.Domain;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddDomainServices(this IServiceCollection services, IConfiguration configuration)
    {
        return services;
    }
}