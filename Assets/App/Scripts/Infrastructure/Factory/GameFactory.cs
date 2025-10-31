using System.Collections.Generic;
using App.Scripts.Infrastructure.PersistentProgress;

namespace App.Scripts.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    public IEnumerable<ISavedProgress> ProgressWriters { get; }
  }
}