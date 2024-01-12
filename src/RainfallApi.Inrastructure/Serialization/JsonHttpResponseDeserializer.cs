using System.Text.Json;
using RestEase;

namespace RainfallApi.Infrastructure.Serialization;

/// <summary>
///     Class for deserialization of response from Rest Ease initiated request.
/// </summary>
/// <seealso cref="RestEase.ResponseDeserializer" />
public class JsonHttpResponseDeserializer : ResponseDeserializer
{
    /// <summary>
    ///     The json naming policy.
    /// </summary>
    private readonly JsonNamingPolicy _jsonNamingPolicy;

    /// <summary>
    ///     Initializes a new instance of the <see cref="JsonHttpResponseDeserializer" /> class.
    /// </summary>
    public JsonHttpResponseDeserializer()
    {
        _jsonNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    /// <inheritdoc />
    public override T Deserialize<T>(
        string content,
        HttpResponseMessage response,
        ResponseDeserializerInfo info) =>
        string.IsNullOrWhiteSpace(content)
            ? default
            : JsonSerializer.Deserialize<T>(
                content,
                new JsonSerializerOptions
                {
                    PropertyNamingPolicy = _jsonNamingPolicy,
                });
}