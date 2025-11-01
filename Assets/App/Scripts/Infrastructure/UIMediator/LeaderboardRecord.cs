using System;
using TMPro;
using UnityEngine;

public class LeaderboardRecord : MonoBehaviour
{
    public TimeSpan Time;

    [SerializeField] private TMP_Text placeText;
    [SerializeField] private TMP_Text nameText;
    [SerializeField] private TMP_Text timeText;
    
    [SerializeField]public string _playerName;

    [SerializeField]public float _timeFloat;
    private int _place;
  
    private void Start()
    {
        Setup(_place, _playerName, TimeSpan.FromSeconds(_timeFloat));
    }
    public void Setup(int place, string playerName, TimeSpan time)
    {
        _playerName = playerName;
        _timeFloat = (float)time.TotalSeconds;
        _place = place;
        Time = time;
        placeText.text = place.ToString();
        nameText.text = playerName;
        timeText.text = time.ToString(@"mm\:ss");
    }
}