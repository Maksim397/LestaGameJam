using App.Scripts.Libs.LoadingScreen;
using UnityEngine;

namespace App.Scripts.Infrastructure.UIMediator
{
  public class UiMediator : MonoBehaviour
  {
    [SerializeField] private LoadingCurtain _loadingScreen;
    [SerializeField] private PauseWindow _pauseWindow;
  
    
    public void ShowLoadingScreen() => _loadingScreen.Show();
    public void HideLoadingScreen() => _loadingScreen.Hide();
    
    public void ShowPauseWindow() => _pauseWindow.Show(); 
    public void HidePauseWindow() => _pauseWindow.Hide();
  }
}