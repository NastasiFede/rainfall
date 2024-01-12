
using RainfallApi.Application.Models;

namespace RainfallApi.Application.Services;

public class RainfallManagementService : IRainfallManagementService
{
    public Task<RainfallReadingResponse> Get(string stationId, int count)
    {
        throw new NotImplementedException();
    }
}