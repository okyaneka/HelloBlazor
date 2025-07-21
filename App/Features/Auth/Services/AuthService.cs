using System.Text.Json;
using HelloBlazor.App.Features.Auth.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HelloBlazor.App.Features.Auth.Services;

public class AuthService(Service service, Token auth) : IAuthService
{
  private readonly Service service = service;
  private bool? isLoggedIn;

  public async Task<LoginResponse> LoginAsync(LoginModel model)
  {
    var res = await service.PostAsync<LoginResponse, LoginModel>("/trainer/v1/login", model);
    var token = res.Data.Token;
    await auth.SetToken(token);
    return res;
  }

  public async Task LogoutAsync()
  {
    await auth.ClearToken();
  }

  public async Task<string?> GetTokenAsync()
  {
    return await auth.GetToken();
  }

  public async Task<bool> IsLoggedInAsync()
  {
    if (!isLoggedIn.HasValue)
    {
      var token = await GetTokenAsync();
      isLoggedIn = !string.IsNullOrEmpty(token);
    }

    return isLoggedIn.Value;
  }
}