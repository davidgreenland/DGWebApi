using System.Text.Json.Serialization;

namespace DGWebApi.Models;

public class ErrorReponse
{
    [JsonPropertyName("error")]
    public string? Message { get; set; }

    [JsonPropertyName("status")]
    public int Status { get; set; }
}