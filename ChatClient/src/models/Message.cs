using System.Text.Json.Serialization;

namespace models;


public class Message
{
    [JsonPropertyName("user")]
    public string? Sender { get; set; }

    [JsonPropertyName("content")]
    public string? Payload { get; set; }
}
