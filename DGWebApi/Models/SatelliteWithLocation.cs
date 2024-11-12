using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class SatelliteWithLocation
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }
    [JsonPropertyName("id")]
    public int Id { get; set; }
    [JsonPropertyName("latitude")]
    public decimal Latitude { get; set; }
    [JsonPropertyName("longitude")]
    public decimal Longitude { get; set; }
    [JsonPropertyName("altitude")]
    public decimal Altitude { get; set; }
    [JsonPropertyName("velocity")]
    public decimal Velocity { get; set; }
    [JsonPropertyName("timezone_id")]
    public string? TimezoneId { get; set; }
    [JsonPropertyName("units")]
    public string? Units { get; set; }
    [JsonPropertyName("offset")]
    public decimal Offset { get; set; }
    [JsonPropertyName("country_code")]
    public string? CountryCode { get; set; }
    [JsonPropertyName("map_url")]
    public string? MapUrl { get; set; }

}
