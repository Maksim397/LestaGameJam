using App.Scripts.Infrastructure.EntryPoint;
using App.Scripts.Scenes.States;
using Zenject;

namespace App.Scripts.Scenes.Installers
{
  public class InstallerGameEntryPoint : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.BindInterfacesAndSelfTo<EntryPointStarter<StateSetupLevel>>().AsSingle();
    }
  }
}