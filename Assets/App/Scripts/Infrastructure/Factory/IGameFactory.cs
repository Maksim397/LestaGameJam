using System.Collections.Generic;
using App.Scripts.Infrastructure.PersistentProgress;

namespace App.Scripts.Infrastructure.Factory
{
  public interface IGameFactory
  {
    IEnumerable<ISavedProgress> ProgressWriters { get; }
  }
}