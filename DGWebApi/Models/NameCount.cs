using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class NameCount
{
    [JsonPropertyName("count")]
    public int Count { get; set; }

    [JsonPropertyName("name")]
    public string? Name { get; set; }

    [JsonPropertyName("age")]
    public int Age { get; set; }
}
