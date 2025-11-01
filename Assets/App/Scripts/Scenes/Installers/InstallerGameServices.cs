using App.Scripts.Infrastructure.Camera;
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

    public override void InstallBindings()
    {
      Container.Bind<ICameraService>().To<CameraService>().AsSingle().WithArguments(_camera);
      Container.Bind<Table>().FromInstance(_table).AsSingle();
      Container.Bind<PizzaContainer>().FromInstance(_pizzaContainer).AsSingle();
      Container.Bind<LevelModel>().AsSingle();
      Container.BindInterfacesTo<IngredientDragService>().AsSingle();
      Container.Bind<IIngredientInteractor>().To<IngredientInteractor>().AsSingle();
    }
  }
}