using HelloBlazor.App.Features;
using HelloBlazor.App.Features.Auth.Services;
using HelloBlazor.App.Features.Trainer.Services;

namespace HelloBlazor.App.Extensions;

public static class ServiceExtension
{
  public static IServiceCollection AddServiceExtension(this IServiceCollection services, string apiBaseUrl)
  {
    services.AddScoped<Token>();
    services.AddScoped<Service>();
    services.AddHttpClient<Service>(client =>
    {
      client.BaseAddress = new Uri(apiBaseUrl);
    });

    services.AddScoped<IAuthService, AuthService>();
    services.AddScoped<ITrainerService, TrainerService>();

    return services;
  }
}