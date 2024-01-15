
using RainfallApi.Application.Models;

namespace RainfallApi.Application.Services;

public interface IRainfallManagementService
{
    Task<RainfallReadingResponse> Get(string stationId, int count);
}