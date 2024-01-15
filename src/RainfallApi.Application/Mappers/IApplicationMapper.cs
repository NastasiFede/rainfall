using RainfallApi.Application.Models;
using RainfallApi.Infrastructure.EnvironmentAgency.Models;

namespace RainfallApi.Application.Mappers;

public interface IApplicationMapper
{
    RainfallReading ToReading(Item item);
}