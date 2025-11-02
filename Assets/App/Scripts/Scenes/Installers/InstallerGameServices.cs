using App.Scripts.Infrastructure.Camera;
using App.Scripts.Infrastructure.Factory;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Scenes.Features.Level;
using UnityEngine;
using Zenject;

namespace App.Scripts.Scenes.Installers
{
  public class InstallerGameServices : MonoInstaller
  {
    [SerializeField] private Camera _camera;
    [SerializeField] private Table _table;
    [SerializeField] private PizzaContainer _pizzaContainer;
    [SerializeField] private UiMediator _uiMediator;

    public override void InstallBindings()
    {
      Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
      Container.Bind<ICameraService>().To<CameraService>().AsSingle().WithArguments(_camera);
      Container.Bind<IIngredientInteractor>().To<IngredientInteractor>().AsSingle();
      Container.BindInterfacesTo<IngredientDragService>().AsSingle();

      Container.Bind<PizzaContainer>().FromInstance(_pizzaContainer).AsSingle();
      Container.Bind<UiMediator>().FromInstance(_uiMediator).AsSingle();
      Container.Bind<Table>().FromInstance(_table).AsSingle();
      
      Container.Bind<LevelModel>().AsSingle();
    }
  }
}