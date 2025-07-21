using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HelloBlazor.App.Features;

public class Token(ProtectedLocalStorage localStorage)
{
  string? token { get; set; }

  public async Task SetToken(string token)
  {
    await localStorage.SetAsync("AuthToken", token);
    this.token = token;
  }

  public async Task ClearToken()
  {
    await localStorage.DeleteAsync("AuthToken");
    token = null;
  }

  public async Task<string?> GetToken()
  {
    if (token == null)
    {
      var result = await localStorage.GetAsync<string>("AuthToken");
      token = result.Value ?? string.Empty;
      await SetToken(token);
    }
    return token;
  }
}