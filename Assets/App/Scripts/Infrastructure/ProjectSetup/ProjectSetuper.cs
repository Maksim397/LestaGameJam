using App.Scripts.Infrastructure.ProjectSetup.ProjectSettings.Config;
using App.Scripts.Infrastructure.SaveLoad;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.LoadingScreen;
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

    public ProjectSetuper(ConfigProjectSettings configProjectSettings, IStaticDataService staticDataService,
      ISaveLoadService saveLoadService, UiMediator uiMediator)
    {
      _configProjectSettings = configProjectSettings;
      _staticDataService = staticDataService;
      _saveLoadService = saveLoadService;
      _uiMediator = uiMediator;
    }

    public void Initialize()
    {
      _uiMediator.ShowLoadingScreen();

      SetupFrameRate();

      LoadStaticData();
      LoadProgress();
    }

    private void SetupFrameRate() => Application.targetFrameRate = _configProjectSettings.TargetFps;
    private void LoadStaticData() => _staticDataService.LoadAll();
    private void LoadProgress() => _saveLoadService.LoadProgress();
  }
}