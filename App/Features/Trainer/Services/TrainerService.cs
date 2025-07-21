using System.Text.Json;
using HelloBlazor.App.Features.Trainer.Models;
using HelloBlazor.App.Helpers;

namespace HelloBlazor.App.Features.Trainer.Services;

public class TrainerService(Service service) : ITrainerService
{
  public async Task<DefaultListResponse<TrainerItem>> GetTrainerListAsync(object? parameters = null)
  {
    var path = "/program/v1/trainer/list";
    if (parameters is not null)
    {
      var queryParams = QueryStringHelper.ToQueryString(parameters);
      path += $"?{queryParams}";
    }

    var response = await service.GetAsync<DefaultListResponse<TrainerItem>>(path, null);
    return response;
  }
}