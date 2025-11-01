using App.Scripts.Libs.LoadingScreen;
using UnityEngine;

namespace App.Scripts.Infrastructure.UIMediator
{
  public class UiMediator : MonoBehaviour
  {
    [SerializeField] private LoadingCurtain _loadingScreen;
    [SerializeField] private PauseWindow _pauseWindow;
    [SerializeField] private WinWindow _winWindow;
    [SerializeField] private GameOverWindow _gameOverWindow;
    [SerializeField] private StartWindow _startWindow;
    [SerializeField] private InGameWindow _inGameWindow;
    public void ShowLoadingScreen() => _loadingScreen.Show();
    public void HideLoadingScreen() => _loadingScreen.Hide();
    
    public void ShowPauseWindow() => _pauseWindow.Show(); 
    public void HidePauseWindow() => _pauseWindow.Hide();

    public void ShowWinWindow() => _winWindow.Show();
    public void HideWinWindow() => _winWindow.Hide();

    public void ShowGameOverWindow() => _gameOverWindow.Show();
    public void HideGameOverWindow() => _gameOverWindow.Hide();
    
    public void ShowStartWindow() => _startWindow.Show();
    public void HideStartWindow() => _startWindow.Hide();

    public void ShowInGameWindow() => _inGameWindow.Show();
    public void HideInGameWindow() => _inGameWindow.Hide();
  }
}