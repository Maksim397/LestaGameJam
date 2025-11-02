using System;
using System.Collections;
using System.Collections.Generic;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.States;
using UnityEngine;
using UnityEngine.UI;
using Zenject;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Transform _contentParent; 
    [SerializeField] private GameObject _recordPrefab;

    [SerializeField] private UiMediator _uiMediator;
    
    [SerializeField]private List<LeaderboardRecord> _records;
    [SerializeField] private WinWindowAnimator _animator;
    [SerializeField] private ScrollRect _scrollRect;
    
    private GameStateMachine _gameStateMachine;
    
    
    [Inject]
    private void Construct(GameStateMachine gameStateMachine) => _gameStateMachine = gameStateMachine;
    
    public void Show()
    {
        _animator.Show();
        gameObject.SetActive(true);
    } 
    public void Hide()
    {
        gameObject.SetActive(false);
        _animator.Hide();
    }

    private void Start()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenu);
        _uiMediator.HideInGameWindow();
    }

    private void OnDestroy() => _mainMenuButton.onClick.RemoveListener(OnMainMenu);

    private void OnMainMenu()
    {
        Hide();
        _gameStateMachine.ChangeState<StateSetupLevel>();
    }
  
    public void SetPlayer(string name, TimeSpan time)
    {
        LeaderboardRecord playerRecord = _records.Find(r => r._playerName == name);
        if (playerRecord != null)
        {
            playerRecord._timeFloat = (float)time.TotalSeconds;
            playerRecord.Time = time;
        }
        else
        {
            GameObject go = Instantiate(_recordPrefab, _contentParent);
            playerRecord = go.GetComponent<LeaderboardRecord>();
            playerRecord._playerName = name;
            playerRecord._timeFloat = (float)time.TotalSeconds;
            playerRecord.Time = time;
            _records.Add(playerRecord);
        }
        
        _records.Sort((a, b) => a._timeFloat.CompareTo(b._timeFloat));
        for (int i = 0; i < _records.Count; i++)
        {
            LeaderboardRecord record = _records[i];
            record.Setup(i + 1, record._playerName, TimeSpan.FromSeconds(record._timeFloat));
            record.transform.SetSiblingIndex(i);
        }
    }
   

    
  
}
