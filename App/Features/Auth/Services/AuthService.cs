using System.Text.Json;
using HelloBlazor.App.Features.Auth.Models;
using Microsoft.AspNetCore.Components.Server.ProtectedBrowserStorage;

namespace HelloBlazor.App.Features.Auth.Services;

public class AuthService(Service service, ProtectedLocalStorage localStorage) : IAuthService
{
  private readonly Service service = service;
  private readonly ProtectedLocalStorage localStorage = localStorage;
  private bool? isLoggedIn;

  public async Task<LoginResponse> LoginAsync(LoginModel model)
  {
    var res = await service.PostAsync<LoginResponse, LoginModel>("/trainer/v1/login", model);
    var token = res.Data.Token;
    await localStorage.SetAsync("AuthToken", token);

    return res;
  }

  public async Task LogoutAsync()
  {
    await localStorage.DeleteAsync("AuthToken");
  }

  public async Task<string> GetTokenAsync()
  {
    var result = await localStorage.GetAsync<string>("AuthToken");
    return result.Value ?? string.Empty;
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