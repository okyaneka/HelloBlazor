using System.Text.Json;
using HelloBlazor.App.Features.Trainer.Models;

namespace HelloBlazor.App.Features.Trainer.Services;

public class TrainerService(Service service) : ITrainerService
{
  public async Task<DefaultListResponse<TrainerItem>> GetTrainerListAsync()
  {
    var response = await service.GetAsync<DefaultListResponse<TrainerItem>>("/program/v1/trainer/list", null);

    return response;
  }
}