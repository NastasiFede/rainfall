using Newtonsoft.Json;

namespace RainfallApi.Infrastructure.EnvironmentAgency.Models;

public class ReadingResponse
{
    [JsonProperty("@context")]
    public string Context { get; set; }

    public MetaData Meta { get; set; }

    public List<Item> Items { get; set; }
}