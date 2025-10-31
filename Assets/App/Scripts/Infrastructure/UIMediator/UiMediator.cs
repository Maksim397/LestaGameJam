using App.Scripts.Libs.LoadingScreen;
using UnityEngine;

namespace App.Scripts.Infrastructure.UIMediator
{
  public class UiMediator : MonoBehaviour
  {
    [SerializeField] private LoadingCurtain _loadingScreen;
    
    public void ShowLoadingScreen() => _loadingScreen.Show();
    public void HideLoadingScreen() => _loadingScreen.Hide();
  }
}