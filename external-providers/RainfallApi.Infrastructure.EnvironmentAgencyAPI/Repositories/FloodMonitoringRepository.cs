using RainfallApi.Infrastructure.EnvironmentAgency.ApiClients;
using RainfallApi.Infrastructure.EnvironmentAgency.Models;

namespace RainfallApi.Infrastructure.EnvironmentAgency.Repositories;

public class FloodMonitoringRepository : IFloodMonitoringRepository
{
    private readonly IFloodMonitoringApiClient _floodMonitoringApiClient;

    public FloodMonitoringRepository(IFloodMonitoringApiClient floodMonitoringApiClient)
    {
        _floodMonitoringApiClient = floodMonitoringApiClient;
    }

    public async Task<ReadingResponse> GetReading(string stationId, int count)
    {
        return await _floodMonitoringApiClient.GetStationsReadings(stationId, count);
    }
}