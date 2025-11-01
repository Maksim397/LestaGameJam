using App.Scripts.Infrastructure.PersistentProgress.Data;

namespace App.Scripts.Infrastructure.SaveLoad
{
  public interface ISaveLoadService
  {
    void SaveProgress();
    PlayerProgress LoadProgress();
  }
}