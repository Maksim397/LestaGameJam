using App.Scripts.Infrastructure.Factory;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.Configs.Loader;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.Installers
{
  public class InstallerProjectServices : MonoInstaller
  {
    [SerializeField] private UiMediator _uiMediator;

    public override void InstallBindings()
    {
      Container.Bind<UiMediator>().FromInstance(_uiMediator).AsSingle();

      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
      Container.Bind<IStaticDataService>().To<StaticDataService>().AsSingle();
      Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();
      Container.Bind<ISaveLoadService>().To<SaveLoadService>().AsSingle();
      Container.Bind<IConfigsLoader>().To<ConfigsLoader>().AsSingle();
    }
  }
}