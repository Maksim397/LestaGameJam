using App.Scripts.Infrastructure.PersistentProgress.Data;

namespace App.Scripts.Infrastructure.PersistentProgress
{
  public interface ISavedProgress : ISavedProgressReader
  {
    void UpdateProgress(PlayerProgress progress);
  }
}