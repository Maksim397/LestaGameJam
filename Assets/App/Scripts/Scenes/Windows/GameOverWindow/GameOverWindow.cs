using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private UiMediator _uiMediator;
    [SerializeField] private GameOverWindowAnimator _animator;
    
    private GameStateMachine _gameStateMachine;
    
    
    [Inject]
    private void Construct(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;

    public void Show()
    {
        _animator.Show();
        gameObject.SetActive(true);
        _uiMediator.HideInGameWindow();
    }

    public void Hide()
    {
        _animator.Hide();
        gameObject.SetActive(false);
    }
    
    
    private void Start()
    {
        _restartButton.onClick.AddListener(OnRestart);
        _mainMenuButton.onClick.AddListener(OnMainMenu);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.AddListener(OnRestart);
        _mainMenuButton.onClick.RemoveListener(OnMainMenu);
    }
    
  
    private void OnRestart()
    {
        Hide();
        _gameStateMachine.ChangeState<StateSetupLevel>();

    }
  
    private void OnMainMenu()
    {
    
    }
    
}
