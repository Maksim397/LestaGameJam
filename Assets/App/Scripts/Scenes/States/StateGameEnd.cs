using System;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.Features.Level;
using App.Scripts.Scenes.Features.Level.Data;

namespace App.Scripts.Scenes.States
{
  public class StateGameEnd : GameState
  {
    private readonly LevelModel _levelModel;
    private readonly UiMediator _uiMediator;
    public StateGameEnd(LevelModel levelModel, UiMediator uiMediator)
    {
      _levelModel = levelModel;
      _uiMediator = uiMediator;
    }
    
    public override void OnEnterState()
    {
      if (_levelModel.LevelResult == LevelResult.Win)
      {
        _uiMediator.ShowWinWindow();
      }
      else if (_levelModel.LevelResult == LevelResult.Loose)
      {
        _uiMediator.ShowGameOverWindow();
      }
      else
      {
        throw new Exception("Unknown level result");
      }
    }
  }
}