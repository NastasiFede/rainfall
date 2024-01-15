using RainfallApi.Infrastructure.EnvironmentAgency.Models;

namespace RainfallApi.Infrastructure.EnvironmentAgency.Repositories;

public interface IFloodMonitoringRepository
{
    Task<ReadingResponse> GetReading(string stationId, int count);
}