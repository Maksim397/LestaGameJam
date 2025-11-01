using App.Scripts.Infrastructure.PersistentProgress.Data;

namespace App.Scripts.Infrastructure.PersistentProgress
{
  public interface ISavedProgressReader
  {
    void LoadProgress(PlayerProgress progress);
  }
}