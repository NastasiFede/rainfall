using RainfallApi.Application.Models;
using RainfallApi.Infrastructure.EnvironmentAgency.Models;

namespace RainfallApi.Application.Mappers;

public class ApplicationMapper : IApplicationMapper
{
    public RainfallReading ToReading(Item item) => 
        new()
        {
            AmountMeasured = item.Value,
            DateMeasured = item.DateTime,
        };
}