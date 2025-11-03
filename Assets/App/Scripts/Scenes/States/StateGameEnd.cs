using System;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.StaticData;
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
    private readonly IStaticDataService _staticData;
    private readonly ISaveLoadService _saveLoadService;
    public StateGameEnd(LevelModel levelModel, UiMediator uiMediator, IPersistentProgressService progress, 
      IStaticDataService staticData, ISaveLoadService saveLoadService)
    {
      _levelModel = levelModel;
      _uiMediator = uiMediator;
      _progress = progress;
      _staticData = staticData;
      _saveLoadService = saveLoadService;
    }
    
    public override void OnEnterState()
    {
      if (_levelModel.LevelResult == LevelResult.Win)
      {
        if(_progress.Progress.BestScore < LevelScore().TotalSeconds)
        {
          _progress.Progress.BestScore = (float)LevelScore().TotalSeconds;
          _saveLoadService.SaveProgress(); 
        }
        
        _uiMediator.ShowWinWindow();
        _uiMediator.SetPlayer(PlayerName(),  LevelScore());
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
    
    private string PlayerName() => "You";
    private TimeSpan LevelScore() => 
      TimeSpan.FromSeconds(_staticData.Levels.Data[0].LevelTimeSeconds) - _uiMediator.GetTime();
  }
}