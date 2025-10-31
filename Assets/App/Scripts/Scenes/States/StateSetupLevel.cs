using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using UnityEngine;

namespace App.Scripts.Scenes.States
{
  public class StateSetupLevel : GameState
  {
    private readonly UiMediator _uiMediator;
    public StateSetupLevel(UiMediator uiMediator)
    {
      _uiMediator = uiMediator;
    }
    
    public override void OnEnterState()
    {
      _uiMediator.HideLoadingScreen();
      
      StateMachine.ChangeState<StateProcessGame>();
    }
  }
}