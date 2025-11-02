using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Scenes.States
{
  public class StateSetupLevel : GameState
  {
    private readonly UiMediator _uiMediator;
    private readonly IPersistentProgressService _persistentProgress;
    private readonly ISaveLoadService _saveLoadService;

    public StateSetupLevel(UiMediator uiMediator, IPersistentProgressService persistentProgress, ISaveLoadService saveLoadService)
    {
      _uiMediator = uiMediator;
      _persistentProgress = persistentProgress;
      _saveLoadService = saveLoadService;
    }
    
    public override async UniTask OnEnterStateAsync()
    {
      _uiMediator.HideLoadingScreen();

      if (_persistentProgress.Progress.PlayerName == null)
      { 
        _persistentProgress.Progress.PlayerName = await _uiMediator.ShowSetNameWindow();
        _saveLoadService.SaveProgress();
      }

      StateMachine.ChangeState<StateProcessGame>();
    }
  }
}