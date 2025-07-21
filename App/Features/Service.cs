using System.Net;
using System.Net.Http.Headers;
using System.Text.Json;
using HelloBlazor.App.Features.Auth.Services;
using HelloBlazor.App.Helpers;
using Microsoft.AspNetCore.Components;

namespace HelloBlazor.App.Features;

public class Service(HttpClient httpClient, Token auth, NavigationManager navigation)
{
  private readonly HttpClient httpClient = httpClient;

  private async Task UseTokenIfExists()
  {
    var token = await auth.GetToken();
    if (!string.IsNullOrEmpty(token))
    {
      httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);
    }
  }

  public async Task<TValue> GetAsync<TValue>(string url, object? query)
  {
    await UseTokenIfExists();
    var queryString = query != null ? "?" + QueryStringHelper.ToQueryString(query) : string.Empty;
    var res = await httpClient.GetAsync(url + queryString);

    if (!res.IsSuccessStatusCode)
      await HandleError(res);

    var data = await res.Content.ReadFromJsonAsync<TValue>() ?? throw new Exception("Response content is null");

    return data;
  }

  public async Task<TValue> PostAsync<TValue, TRequest>(string url, TRequest request)
  {
    await UseTokenIfExists();
    var json = JsonSerializer.Serialize(request);
    var content = new StringContent(json, System.Text.Encoding.UTF8, "application/json");
    var res = await httpClient.PostAsync(url, content);

    if (!res.IsSuccessStatusCode)
      await HandleError(res);

    var data = await res.Content.ReadFromJsonAsync<TValue>() ?? throw new Exception("Response content is null");

    return data;
  }

  private async Task HandleError(HttpResponseMessage res)
  {
    if (res.StatusCode == HttpStatusCode.Unauthorized)
    {
      await auth.ClearToken();
      navigation.NavigateTo("/login");
      return;
    }

    var message = res.ReasonPhrase;
    if (res.Content != null)
    {
      var errorContent = await res.Content.ReadFromJsonAsync<DefaultResponse<object>>();
      message = errorContent?.Message ?? message;
    }
    throw new Exception(message);
  }
}