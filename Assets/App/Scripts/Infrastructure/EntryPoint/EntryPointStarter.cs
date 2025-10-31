using App.Scripts.Libs.StateMachine;
using Zenject;

namespace App.Scripts.Infrastructure.EntryPoint
{
  public class EntryPointStarter<T> : IInitializable, ITickable where T : GameState
  {
    private readonly GameStateMachine _gameStateMachine;

    public EntryPointStarter(GameStateMachine gameStateMachine)
    {
      _gameStateMachine = gameStateMachine;
    }

    public void Initialize()
    {
      _gameStateMachine.ChangeState<T>();
    }

    public void Tick()
    {
      _gameStateMachine.Tick();
    }
  }
}