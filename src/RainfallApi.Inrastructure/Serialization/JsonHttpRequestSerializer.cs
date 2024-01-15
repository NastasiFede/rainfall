using System.Text.Json;
using System.Text.Json.Serialization;
using RestEase;

namespace RainfallApi.Infrastructure.Serialization;

/// <summary>
/// Class for serialization of request initiated by Rest Ease.
/// </summary>
/// <seealso cref="RestEase.RequestBodySerializer" />
public class JsonHttpRequestSerializer : RequestBodySerializer
{
    /// <summary>
    /// The json naming policy.
    /// </summary>
    private readonly JsonNamingPolicy _jsonNamingPolicy;

    /// <summary>
    /// Initializes a new instance of the <see cref="JsonHttpRequestSerializer"/> class.
    /// </summary>
    public JsonHttpRequestSerializer()
    {
        _jsonNamingPolicy = JsonNamingPolicy.CamelCase;
    }

    /// <inheritdoc />
    public override HttpContent SerializeBody<T>(T body, RequestBodySerializerInfo info)
    {
        if (body == null)
        {
            return null;
        }

        string serializedString = JsonSerializer.Serialize(
            (object)body,
            new JsonSerializerOptions
            {
                PropertyNamingPolicy = _jsonNamingPolicy,
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
            });

        var stringContent = new StringContent(serializedString);
        stringContent.Headers.ContentType.MediaType = "application/json";

        return stringContent;
    }
}