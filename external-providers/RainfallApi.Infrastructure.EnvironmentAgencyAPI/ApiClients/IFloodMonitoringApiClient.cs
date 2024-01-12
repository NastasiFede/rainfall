using RainfallApi.Infrastructure.EnvironmentAgency.Models;
using RestEase;

namespace RainfallApi.Infrastructure.EnvironmentAgency.ApiClients;

public interface IFloodMonitoringApiClient
{
    /// <summary>
    /// Get balances
    /// </summary>
    /// <param name="stationId">Station unique identifier</param>
    /// <param name="limit">Items limit</param>
    /// <param name="sort">Sorting</param>
    /// <returns>List of balances</returns>
    [Post("flood-monitoring/id/stations/{stationId}/readings")]
    public Task<ReadingResponse> GetStationsReadings([Path] string stationId, [Query("_limit")] int limit, [Query("_sorted")] string sort = "desc");
}