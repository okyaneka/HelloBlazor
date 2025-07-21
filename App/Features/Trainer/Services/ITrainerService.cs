using HelloBlazor.App.Features.Trainer.Models;

namespace HelloBlazor.App.Features.Trainer.Services;

public interface ITrainerService
{
  Task<DefaultListResponse<TrainerItem>> GetTrainerListAsync();
}