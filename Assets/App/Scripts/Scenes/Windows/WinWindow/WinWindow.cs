using System;
using System.Collections.Generic;
using App.Scripts.Infrastructure.UIMediator;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Transform _contentParent; 
    [SerializeField] private GameObject _recordPrefab;

    [SerializeField] private UiMediator _uiMediator;
    
    [SerializeField]private List<LeaderboardRecord> _records;
    [SerializeField] private WinWindowAnimator _animator;
    
    
    public void Show()
    {
        _animator.Show();
        gameObject.SetActive(true);
    } 
    public void Hide()
    {
        _animator.Hide();
        gameObject.SetActive(false);
    }

    private void Start()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenu);
        _uiMediator.HideInGameWindow();
    }

    private void OnDestroy() => _mainMenuButton.onClick.RemoveListener(OnMainMenu);

    private void OnMainMenu()
    {
        
    }
  
    public void SetPlayer(string name, TimeSpan time)
    {
        LeaderboardRecord record = _records.Find(r => r._playerName == name);
        if (record != null)
        {
            record._timeFloat = (float)time.TotalSeconds;
            record.Time = time;
        }
        else
        {
            GameObject go = Instantiate(_recordPrefab, _contentParent);
            record = go.GetComponent<LeaderboardRecord>();
            record._playerName = name;
            record._timeFloat = (float)time.TotalSeconds;
            record.Time = time;
            _records.Add(record);
        }
        
        _records.Sort((a, b) => a._timeFloat.CompareTo(b._timeFloat));
        for (int i = 0; i < _records.Count; i++)
        {
            record = _records[i];
            record.Setup(i + 1, record._playerName, TimeSpan.FromSeconds(record._timeFloat));
            record.transform.SetSiblingIndex(i);
        }
    }
    
    
  
}
