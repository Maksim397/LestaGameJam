using Cysharp.Threading.Tasks;

namespace App.Scripts.Libs.StateMachine
{
  public abstract class GameState
  {
    public GameStateMachine StateMachine { get; set; }

    public virtual void OnEnterState()
    {
      
    }
    
    public virtual UniTask OnEnterStateAsync()
    {
      return UniTask.CompletedTask;
    }
    
    public virtual void OnExitState()
    {
      
    }


    public virtual void Tick()
    {
      
    }
  }
}