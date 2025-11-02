using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.PersistentProgress.Data;
using App.Scripts.Infrastructure.ProjectSetup.ProjectSettings.Config;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using UnityEngine;
using Zenject;

namespace App.Scripts.Infrastructure.ProjectSetup
{
  public class ProjectSetuper : IInitializable
  {
    private readonly ConfigProjectSettings _configProjectSettings;
    private readonly IStaticDataService _staticDataService;
    private readonly ISaveLoadService _saveLoadService;
    private readonly UiMediator _uiMediator;
    private readonly GameStateMachine _gameStateMachine;
    private readonly IPersistentProgressService _persistentProgress;

    public ProjectSetuper(ConfigProjectSettings configProjectSettings, IStaticDataService staticDataService,
      ISaveLoadService saveLoadService, UiMediator uiMediator, GameStateMachine gameStateMachine, 
      IPersistentProgressService persistentProgress)
    {
      _configProjectSettings = configProjectSettings;
      _staticDataService = staticDataService;
      _saveLoadService = saveLoadService;
      _uiMediator = uiMediator;
      _gameStateMachine = gameStateMachine;
      _persistentProgress = persistentProgress;
    }

    public void Initialize()
    {
      _uiMediator.ShowLoadingScreen();

      SetupFrameRate();

      LoadStaticData();
      LoadProgress();

      _gameStateMachine.ChangeState<StateSetupLevel>();
    }

    private void SetupFrameRate() => Application.targetFrameRate = _configProjectSettings.TargetFps;
    private void LoadStaticData() => _staticDataService.LoadAll();
    private void LoadProgress() => _persistentProgress.Progress = _saveLoadService.LoadProgress() ?? new PlayerProgress();
  }
}