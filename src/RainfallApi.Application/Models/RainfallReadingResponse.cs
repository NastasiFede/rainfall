namespace RainfallApi.Application.Models;

/// <summary>
/// Rainfall reading response
/// </summary>
public class RainfallReadingResponse
{
    public IReadOnlyCollection<RainfallReading> Readings { get; set; }
}