using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;
    [SerializeField] private Transform _contentParent; 
    [SerializeField] private GameObject _recordPrefab;
    
    
    [SerializeField]private List<LeaderboardRecord> _records;
    
    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void Start()
    {
        AddPlayer("First", TimeSpan.FromSeconds(10f));
        AddPlayer("Second", TimeSpan.FromSeconds(45f));
        AddPlayer("Forth", TimeSpan.FromSeconds(90f));
        AddPlayer("Third", TimeSpan.FromSeconds(60f));
        AddPlayer("Fifth", TimeSpan.FromSeconds(120f));
        _mainMenuButton.onClick.AddListener(OnMainMenu);
    }

    private void OnDestroy() => _mainMenuButton.onClick.RemoveListener(OnMainMenu);

    private void OnMainMenu()
    {
        
    }
  
    private void OnRestart()
    {
        
    }
    public void AddPlayer(string name, TimeSpan time)
    {
        GameObject go = Instantiate(_recordPrefab, _contentParent);
        LeaderboardRecord record = go.GetComponent<LeaderboardRecord>();
        record._playerName = name;
        record._timeFloat = (float)time.TotalSeconds;
        record.Time = time;
        
        _records.Add(record);
        _records.Sort((a, b) => a._timeFloat.CompareTo(b._timeFloat));
        for (int i = 0; i < _records.Count; i++)
        {
            record = _records[i];
            record.Setup(i + 1, record._playerName, TimeSpan.FromSeconds(record._timeFloat));
            record.transform.SetSiblingIndex(i);
        }
    }
    
    
  
}
