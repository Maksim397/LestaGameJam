using System;
using System.Collections;
using App.Scripts.Infrastructure.UIMediator;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameWindow : MonoBehaviour
{
    [SerializeField] public Button _pauseButton;
    [SerializeField] public TMP_Text _timer;
    [SerializeField] private UiMediator _uiMediator;
    [SerializeField] public InGameWindowAnimator _animator;

    
    private TimeSpan _timerTime;
    private Coroutine _countdownCoroutine;

    public event Action OnTimerEnd;
    public void StartTimer(TimeSpan startTime)
    {
        _timerTime = startTime;
        _countdownCoroutine = StartCoroutine(CountdownCoroutine(startTime));
    }

    public TimeSpan GetTime()
    {
        return _timerTime;
    }
    public void StopTimer()
    {
        if (_countdownCoroutine != null)
        {
            StopCoroutine(_countdownCoroutine);
            _countdownCoroutine = null;
        }
    }
    
    public void Show()
    {
        gameObject.SetActive(true);
        _pauseButton.gameObject.SetActive(true);
    } 

    public void Hide() => gameObject.SetActive(false);

    void Start()
    {
        _pauseButton.onClick.AddListener(OnPause);
        _pauseButton.gameObject.SetActive(true);
    }

    private void OnDestroy() => _pauseButton.onClick.RemoveListener(OnPause);

    private void OnPause()
    {
        _uiMediator.ShowPauseWindow();
        _pauseButton.gameObject.SetActive(false);
    }
    private IEnumerator CountdownCoroutine(TimeSpan timeSpan)
    {
        TimeSpan remainingTime = timeSpan;

        while (remainingTime.TotalSeconds > 0d)
        {
            UpdateTimerDisplay(remainingTime);

            yield return new WaitForSeconds(1f);
            remainingTime -= TimeSpan.FromSeconds(1f);
            _timerTime = remainingTime;
        }

        UpdateTimerDisplay(TimeSpan.FromSeconds(0f));
        OnTimerEnded();
    }

    public void OnTimerEnded()
    {
        OnTimerEnd?.Invoke(); 
    }

    public void ResetTime()
    {
        StopTimer();
        _timerTime = TimeSpan.FromSeconds(0f);
        UpdateTimerDisplay(TimeSpan.FromSeconds(0f));
    }
    public void AddTime(TimeSpan time)
    {
        StopTimer();
        _timerTime += time;
        StartTimer(_timerTime);
        
        _animator.ScaleTime();
    }

    public void RemoveTime(TimeSpan time)
    {
        StopTimer();
        _timerTime -= time;
        StartTimer(_timerTime);
        
        _animator.ScaleTime();
    }
    private void UpdateTimerDisplay(TimeSpan remainingTime) => _timer.text = remainingTime.ToString(@"mm\:ss");
}
