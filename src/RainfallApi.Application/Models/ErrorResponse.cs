namespace RainfallApi.Application.Models;

/// <summary>
///  Error response
/// </summary>
public class ErrorResponse
{
    public string Message { get; set; }
    public IReadOnlyCollection<ErrorResponse> Detail { get; set; }
}