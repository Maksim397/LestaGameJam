using System;
using App.Scripts.Infrastructure.PersistentProgress;
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
    private readonly IPersistentProgressService _progress;
    public StateGameEnd(LevelModel levelModel, UiMediator uiMediator, IPersistentProgressService progress)
    {
      _levelModel = levelModel;
      _uiMediator = uiMediator;
      _progress = progress;
    }
    
    public override void OnEnterState()
    {
      if (_levelModel.LevelResult == LevelResult.Win)
      {
        _uiMediator.SetPlayer(_progress.Progress.PlayerName, _uiMediator.GetTime());
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