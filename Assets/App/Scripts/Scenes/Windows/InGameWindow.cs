
using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameWindow : MonoBehaviour
{
    [SerializeField] public Button _pauseButton;
    [SerializeField] public TMP_Text _timer;

    private TimeSpan _timerTime;
    private Coroutine countdownCoroutine;

    public void StartTimer(TimeSpan startTime)
    {
        _timerTime = startTime;
        countdownCoroutine = StartCoroutine(CountdownCoroutine(startTime));
    }
    public void StopTimer()
    {
        if (countdownCoroutine != null)
        {
            StopCoroutine(countdownCoroutine);
            countdownCoroutine = null;
        }
    }
    public void Show() => gameObject.SetActive(true);

    public void Hide() => gameObject.SetActive(false);

    void Start() => _pauseButton.onClick.AddListener(OnPause);

    private void OnDestroy() => _pauseButton.onClick.RemoveListener(OnPause);

    private void OnPause()
    {
        
    }
    private IEnumerator CountdownCoroutine(TimeSpan timeSpan)
    {
        TimeSpan remainingTime = timeSpan;

        while (remainingTime.TotalSeconds > 0d)
        {
            UpdateTimerDisplay(remainingTime);

            yield return new WaitForSeconds(1f);

            remainingTime -= TimeSpan.FromSeconds(1f);
        }

        UpdateTimerDisplay(TimeSpan.FromSeconds(0f));
        OnTimerEnded();
    }

    private void OnTimerEnded()
    {
        
    }

    private void UpdateTimerDisplay(TimeSpan remainingTime) => _timer.text = remainingTime.ToString(@"mm\:ss");
}
