using FluentValidation;
using FluentValidation.Results;
using RainfallApi.Application.Mappers;
using RainfallApi.Application.Models;
using RainfallApi.Infrastructure.EnvironmentAgency.Repositories;
using RainfallApi.Infrastructure.Exceptions;

namespace RainfallApi.Application.Services;

public class RainfallManagementService : IRainfallManagementService
{
    private readonly IFloodMonitoringRepository _floodMonitoringRepository;
    private readonly IApplicationMapper _applicationMapper;

    public RainfallManagementService(IFloodMonitoringRepository floodMonitoringRepository, IApplicationMapper applicationMapper)
    {
        _floodMonitoringRepository = floodMonitoringRepository;
        _applicationMapper = applicationMapper;
    }

    public async Task<RainfallReadingResponse> Get(string stationId, int count)
    {
        ValidateCount(count);

        var externalResponse = await _floodMonitoringRepository.GetReading(stationId, count);

        if (!externalResponse.Items.Any())
        {
            throw new ItemNotFoundException($"Reading for station with id={stationId} was not found");

        }

        var response = new RainfallReadingResponse
        {
            Readings = externalResponse.Items.Select(_applicationMapper.ToReading).ToList(),
        };

        return response;
    }

    private void ValidateCount(int count)
    {
        if (count is > 100 or < 1)
        {
            throw new ValidationException("Invalid value", new []{ new ValidationFailure(nameof(count), "The field must be between 1 and 100.") });
        }
    }
}