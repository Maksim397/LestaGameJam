using System;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.Features.Level;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Scenes.States
{
  public class StateSetupLevel : GameState
  {
    private readonly UiMediator _uiMediator;
    private readonly IPersistentProgressService _persistentProgress;
    private readonly ISaveLoadService _saveLoadService;
    private readonly IStaticDataService _staticData;
    private readonly LevelModel _levelModel;

    public StateSetupLevel(UiMediator uiMediator, IPersistentProgressService persistentProgress, 
      ISaveLoadService saveLoadService, IStaticDataService staticData, LevelModel levelModel)
    {
      _uiMediator = uiMediator;
      _persistentProgress = persistentProgress;
      _saveLoadService = saveLoadService;
      _staticData = staticData;
      _levelModel = levelModel;
    }
    
    public override async UniTask OnEnterStateAsync()
    {
      _uiMediator.HideLoadingScreen();

      if (_persistentProgress.Progress.PlayerName == null)
      { 
        _persistentProgress.Progress.PlayerName = await _uiMediator.SetName();
        _saveLoadService.SaveProgress();
      }
      
      await _uiMediator.StartWindow();

      var levelData = _staticData.Levels.Data[0];
      _levelModel.SetLevelData(levelData);

      _uiMediator.ShowInGameWindow();
      _uiMediator.ResetTime();
      _uiMediator.AddTime(TimeSpan.FromSeconds(levelData.LevelTimeSeconds));

      StateMachine.ChangeState<StateProcessGame>();
    }
  }
}