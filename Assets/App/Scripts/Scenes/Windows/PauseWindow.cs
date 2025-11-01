using UnityEngine;
using UnityEngine.UI;

public class PauseWindow : MonoBehaviour
{
  [SerializeField] private Button _resumeButton;
  [SerializeField] private Button _restartButton;
  [SerializeField] private Button _quitButton;

  public void Show()
  {
    gameObject.SetActive(true);
  } 
  
  public void Hide()
  {
    gameObject.SetActive(false);
  }

  private void Start()
  {
    _resumeButton.onClick.AddListener(OnResume);
    _restartButton.onClick.AddListener(OnRestart);
    _quitButton.onClick.AddListener(OnQuit);
  }
  
  private void OnDestroy()
  {
    _resumeButton.onClick.RemoveListener(OnResume);
    _restartButton.onClick.RemoveListener(OnRestart);
    _quitButton.onClick.RemoveListener(OnQuit);
  }
  
  private void OnResume()
  {
    
  }
  
  private void OnRestart()
  {
    
  }
  
  private void OnQuit()
  {
    
  }
}
