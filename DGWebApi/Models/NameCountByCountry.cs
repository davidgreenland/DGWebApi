using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class NameCountByCountry : NameCount
{
    [JsonPropertyName("country_id")]
    public string? CountryId { get; set; }
    
    public string? CountryName { get; set; }
}
