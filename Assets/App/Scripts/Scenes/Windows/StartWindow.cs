using System.Collections;
using System.Collections.Generic;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;

    private GameStateMachine _gameStateMachine;
    private UniTaskCompletionSource _completionSource;
    
    [Inject]
    private void Construct(GameStateMachine gameStateMachine)
    {
        _gameStateMachine = gameStateMachine;
    }
    
    
    public UniTask Show()
    {
        _completionSource = new UniTaskCompletionSource();
        gameObject.SetActive(true);
        
        return _completionSource.Task;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        _startButton.onClick.AddListener(OnStart);
        _quitButton.onClick.AddListener(OnQuit);
    }
  
    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(OnStart);
        _quitButton.onClick.RemoveListener(OnQuit);
    }

    private void OnStart()
    {
        
    }
  
    private void OnQuit()
    {
        
    }
}
