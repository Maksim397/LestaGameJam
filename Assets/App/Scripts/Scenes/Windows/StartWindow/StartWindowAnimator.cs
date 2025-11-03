using System;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using UnityEngine;

public class StartWindowAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _windowTransform;
    [SerializeField] private Transform _startButton;
    [SerializeField] private Transform _quitButton;
    [SerializeField] private Transform _title; 
    [SerializeField] private Config _config;
  
    public void Show()
    {
        CancelAnimation();
        _windowTransform.localScale = Vector3.zero;
        _windowTransform.gameObject.SetActive(true);
        
        var seq = DOTween.Sequence();
        seq.Append(_windowTransform.DOScale(1f, _config.ScaleTime)
            .SetEase(_config.ScaleEase));
        PlaySequence(seq);
    }

    public void Hide()
    {
        CancelAnimation();
        _windowTransform.localScale = Vector3.one;
        _windowTransform.gameObject.SetActive(true);
        
        var seq = DOTween.Sequence();
        seq.Append(_windowTransform.DOScale(0f, _config.HideTime)
            .SetEase(_config.HideEase)
            .OnComplete(() => _windowTransform.gameObject.SetActive(false)));
        
        PlaySequence(seq);
    }
    [Serializable]
    public class Config
    {
        public float ScaleTime = 0.8f;
        public Ease ScaleEase = Ease.OutBack;
        public float HideTime = 0.4f;
        public Ease HideEase = Ease.InBack;
    }
}