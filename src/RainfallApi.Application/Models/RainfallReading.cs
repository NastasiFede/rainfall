namespace RainfallApi.Application.Models;

/// <summary>
/// Rainfall reading
/// </summary>
public class RainfallReading
{
    public DateTime DateMeasured { get; set; }

    public decimal AmountMeasured { get; set; }
}