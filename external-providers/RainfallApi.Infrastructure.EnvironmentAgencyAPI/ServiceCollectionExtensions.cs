using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using RainfallApi.Infrastructure.EnvironmentAgency.Options;
using RainfallApi.Infrastructure.EnvironmentAgency.Repositories;
using RestEase;
using RainfallApi.Infrastructure.EnvironmentAgency.ApiClients;
using RainfallApi.Infrastructure.Serialization;

namespace RainfallApi.Infrastructure.EnvironmentAgency;

public static class ServiceCollectionExtensions
{
    public static IServiceCollection AddEnvironmentAgency(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IFloodMonitoringRepository, FloodMonitoringRepository>();
        services.AddEnvironmentAgencyEndpoint<IFloodMonitoringApiClient>();
        return services;
    }

    private static void AddEnvironmentAgencyEndpoint<T>(this IServiceCollection services)
        where T : class
    {
        services.AddSingleton(
            serviceProvider =>
            {
                var options = serviceProvider.GetService<IOptionsMonitor<EnvironmentAgencyOptions>>()?.CurrentValue;

                T api = new RestClient(options.BaseUrl)
                {
                    RequestBodySerializer = new JsonHttpRequestSerializer(),
                    ResponseDeserializer = new JsonHttpResponseDeserializer(),
                }.For<T>();

                return api;
            });
    }
}