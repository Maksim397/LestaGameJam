using App.Scripts.Infrastructure.PersistentProgress.Data;

namespace App.Scripts.Infrastructure.PersistentProgress
{
  public interface IPersistentProgressService
  {
    PlayerProgress Progress { get; set; }
  }
}