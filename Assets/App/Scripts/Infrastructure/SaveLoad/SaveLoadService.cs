using App.Scripts.Infrastructure.Factory;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Infrastructure.PersistentProgress.Data;
using App.Scripts.Libs;
using UnityEngine;

namespace App.Scripts.Infrastructure.SaveLoad
{
  public class SaveLoadService : ISaveLoadService
  {
    private const string ProgressKey = "Progress";

    private readonly IPersistentProgressService _progressService;
    private readonly IGameFactory _gameFactory;

    public SaveLoadService(IPersistentProgressService progressService, IGameFactory gameFactory)
    {
      _progressService = progressService;
      _gameFactory = gameFactory;
    }

    public void SaveProgress()
    {
      foreach (var progressWriter in _gameFactory.ProgressWriters)
        progressWriter.UpdateProgress(_progressService.Progress);

      PlayerPrefs.SetString(ProgressKey, _progressService.Progress.ToJson());
    }

    public PlayerProgress LoadProgress() => PlayerPrefs.GetString(ProgressKey)?
      .ToDeserialized<PlayerProgress>();
  }
}