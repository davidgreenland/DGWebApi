using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class Location
{
    [JsonPropertyName("latitude")]
    public string? Latitude { get; set; }

    [JsonPropertyName("longitude")]
    public string? Longitude { get; set; }

    [JsonPropertyName("timezone_id")]
    public string? TimezoneId { get; set; }

    [JsonPropertyName("offset")]
    public decimal Offset { get; set; }

    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }

    [JsonPropertyName("map_url")]
    public string? MapUrl { get; set; }
}