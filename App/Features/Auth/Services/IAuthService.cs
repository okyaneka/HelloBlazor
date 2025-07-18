using HelloBlazor.App.Features.Auth.Models;

namespace HelloBlazor.App.Features.Auth.Services;

public interface IAuthService
{
  Task<LoginResponse> LoginAsync(LoginModel model);
  Task LogoutAsync();
  Task<string> GetTokenAsync();
  Task<bool> IsLoggedInAsync();
}