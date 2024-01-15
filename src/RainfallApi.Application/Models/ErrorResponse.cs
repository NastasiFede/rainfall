namespace RainfallApi.Application.Models;

/// <summary>
///  Error response
/// </summary>
public class ErrorResponse
{
    /// <summary>
    /// Error message
    /// </summary>
    public string Message { get; set; }

    /// <summary>
    ///  Details of invalid request property
    /// </summary>
    public IReadOnlyCollection<ErrorDetail> Detail { get; set; }
}