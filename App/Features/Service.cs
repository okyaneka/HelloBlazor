using System.Text.Json;

namespace HelloBlazor.App.Features;

public class Service(HttpClient httpClient)
{
  private readonly HttpClient httpClient = httpClient;

  public async Task<TValue> PostAsync<TValue, TRequest>(string url, TRequest request)
  {
    var json = JsonSerializer.Serialize(request);
    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    var res = await httpClient.PostAsync(url, content);

    if (!res.IsSuccessStatusCode)
    {
      var message = res.ReasonPhrase;
      if (res.Content != null)
      {
        var errorContent = await res.Content.ReadFromJsonAsync<DefaultResponse<object>>();
        message = errorContent?.Message ?? message;
      }
      throw new Exception(message);
    }

    var data = await res.Content.ReadFromJsonAsync<TValue>() ?? throw new Exception("Response content is null");

    return data;
  }
}