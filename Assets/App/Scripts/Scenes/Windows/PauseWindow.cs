using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class PauseWindow : MonoBehaviour
{
  [SerializeField] private Button _resumeButton;
  [SerializeField] private Button _restartButton;
  [SerializeField] private Button _quitButton;
  [SerializeField] private UiMediator _uiMediator;
  
  private GameStateMachine _gameStateMachine;
  
  
  [Inject]
  private void Construct(GameStateMachine gameStateMachine)
  {
      _gameStateMachine = gameStateMachine;
  }
  
  
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
    _gameStateMachine.ChangeState<StateSetupLevel>();
  }
  
  private void OnQuit()
  {
    
  }
}
