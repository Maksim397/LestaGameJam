using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using Zenject;

namespace App.Scripts.Scenes.Installers
{
  public class InstallerStates : MonoInstaller
  {
    public override void InstallBindings()
    {
      Container.Bind<GameState>().To<StateSetupLevel>().AsSingle();
      Container.Bind<GameState>().To<StateProcessGame>().AsSingle();
      Container.Bind<GameState>().To<StateGameEnd>().AsSingle();
      
      Container.BindInterfacesAndSelfTo<GameStateMachine>().AsSingle();
    }
  }
}