using App.Scripts.Infrastructure.PersistentProgress.Data;

namespace App.Scripts.Infrastructure.PersistentProgress
{
  public class PersistentProgressService : IPersistentProgressService
  {
    public PlayerProgress Progress { get; set; }
  }
}