using App.Scripts.Infrastructure.Camera;
using App.Scripts.Scenes.Features.Level;
using UnityEngine;
using Zenject;

namespace App.Scripts.Scenes.Installers
{
  public class InstallerGameServices : MonoInstaller
  {
    [SerializeField] private Camera _camera;
    
    public override void InstallBindings()
    {
      Container.Bind<ICameraService>().To<CameraService>().AsSingle().WithArguments(_camera);
      Container.Bind<LevelModel>().AsSingle();
    }
  }
}