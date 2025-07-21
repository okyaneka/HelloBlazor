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

public class DefaultListResponse<T> : DefaultResponse<ListResponse<T>>
{ }

public class ListResponse<T>
{
  [JsonPropertyName("list")]
  public required List<T> List { get; set; }

  [JsonPropertyName("page")]
  public required int Page { get; set; }

  [JsonPropertyName("total")]
  public required int Total { get; set; }

  [JsonPropertyName("total_page")]
  public required int TotalPage { get; set; }
}