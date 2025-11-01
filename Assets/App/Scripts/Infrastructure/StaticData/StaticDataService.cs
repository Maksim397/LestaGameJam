using App.Scripts.Libs.Configs.Loader;
using App.Scripts.Scenes.Features.Level;

namespace App.Scripts.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly IConfigsLoader _configsLoader;

    public LevelsConfig Levels { get; private set; }

    public StaticDataService(IConfigsLoader configsLoader)
    {
      _configsLoader = configsLoader;
    }

    public void LoadAll()
    {
      Levels = _configsLoader.LoadSoConfig<LevelsConfig>();
    }
  }
}