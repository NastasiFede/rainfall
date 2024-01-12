using Newtonsoft.Json;

namespace RainfallApi.Infrastructure.EnvironmentAgency.Models;

public class MetaData
{
    public string Publisher { get; set; }
    public string Licence { get; set; }
    public string Documentation { get; set; }
    public string Version { get; set; }
    public string Comment { get; set; }
    public List<string> HasFormat { get; set; }
    public int Limit { get; set; }
}