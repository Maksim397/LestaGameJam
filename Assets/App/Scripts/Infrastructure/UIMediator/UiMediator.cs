using System;
using App.Scripts.Libs.LoadingScreen;
using Cysharp.Threading.Tasks;
using Unity.VisualScripting;
using UnityEngine;

namespace App.Scripts.Infrastructure.UIMediator
{
    public class UiMediator : MonoBehaviour
    {
        [SerializeField] private LoadingCurtain _loadingScreen;
        [SerializeField] private PauseWindow _pauseWindow;
        [SerializeField] private WinWindow _winWindow;
        [SerializeField] private GameOverWindow _gameOverWindow;
        [SerializeField] private StartWindow _startWindow;
        [SerializeField] private InGameWindow _inGameWindow;
        [SerializeField] private SetNameWindow _setNameWindow;

        private bool _isTimerRunning;

        public event Action OnTimeEnd;

        private void Start()
        {
            _inGameWindow.OnTimerEnd += OnTimerEnded;
        }

        private void OnDestroy()
        {
            _inGameWindow.OnTimerEnd -= OnTimerEnded;
        }

        private void OnTimerEnded()
        {
            OnTimeEnd?.Invoke();
        }


        public void ShowLoadingScreen() => _loadingScreen.Show();
        public void HideLoadingScreen() => _loadingScreen.Hide();

        public void ShowPauseWindow() => _pauseWindow.Show();
        public void HidePauseWindow() => _pauseWindow.Hide();

        public void ShowWinWindow() => _winWindow.Show();
        public void HideWinWindow() => _winWindow.Hide();

        public void ShowGameOverWindow() => _gameOverWindow.Show();
        public void HideGameOverWindow() => _gameOverWindow.Hide();

        public UniTask StartWindow() => _startWindow.Show();
        public void HideStartWindow() => _startWindow.Hide();

        public void ShowInGameWindow() => _inGameWindow.Show();
        public void HideInGameWindow() => _inGameWindow.Hide();

        public UniTask<string> SetName() => _setNameWindow.Show();
        public void HideSetNameWindow() => _setNameWindow.Hide();


        public void StartCountdown(TimeSpan startTime) => _inGameWindow.StartTimer(startTime);
        public void StopCountdown() => _inGameWindow.StopTimer();

        public void SetPlayer(string playerName, TimeSpan time)
        {
            _winWindow.SetPlayer(playerName, time);
        }
    
    

        public void AddTime(TimeSpan time) => _inGameWindow.AddTime(time);
        public void RemoveTime(TimeSpan time) => _inGameWindow.RemoveTime(time);
        public void ResetTime() => _inGameWindow.ResetTime();
    }
}