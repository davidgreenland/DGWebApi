using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class Satellite
{
    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("id")]
    public int Id { get; set; }
}
