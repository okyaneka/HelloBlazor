using HelloBlazor.App.Features;
using HelloBlazor.App.Features.Auth.Services;

namespace HelloBlazor.App.Extensions;

public static class ServiceExtension
{
  public static IServiceCollection AddServiceExtension(this IServiceCollection services, string apiBaseUrl)
  {
    services.AddScoped<Service>();
    services.AddHttpClient<Service>(client =>
    {
      client.BaseAddress = new Uri(apiBaseUrl);
    });

    services.AddScoped<IAuthService, AuthService>();

    return services;
  }
}