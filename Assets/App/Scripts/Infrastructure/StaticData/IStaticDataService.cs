using App.Scripts.Scenes.Features.Level;

namespace App.Scripts.Infrastructure.StaticData
{
  public interface IStaticDataService
  {
    void LoadAll();
    LevelsConfig Levels { get; }
  }
}