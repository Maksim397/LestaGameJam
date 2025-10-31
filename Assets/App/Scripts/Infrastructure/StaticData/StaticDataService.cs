using App.Scripts.Libs.Configs.Loader;

namespace App.Scripts.Infrastructure.StaticData
{
  public class StaticDataService : IStaticDataService
  {
    private readonly IConfigsLoader _configsLoader;

    public StaticDataService(IConfigsLoader configsLoader)
    {
      _configsLoader = configsLoader;
    }

    public void LoadAll()
    {

    }
  }
}