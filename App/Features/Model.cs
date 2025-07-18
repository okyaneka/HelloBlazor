using System.Text.Json.Serialization;

namespace HelloBlazor.App.Features;

public class DefaultResponse<T>
{
  [JsonPropertyName("status")]
  public int Status { get; set; }

  [JsonPropertyName("message")]
  public required string Message { get; set; }

  [JsonPropertyName("data")]
  public required T Data { get; set; }

  [JsonPropertyName("validation")]
  public object? Validation { get; set; }
}