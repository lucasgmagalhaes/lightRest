using System.Text.Json.Serialization;

namespace LightRest.Testing.Api;

public record Game
{
    [JsonPropertyName("id")]
    public int Id { get; set; }

    [JsonPropertyName("title")]
    public string? Title { get; set; }
}
