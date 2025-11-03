using System;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindowAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _windowTransform;
  
    [SerializeField] private PauseWindowAnimator.Config _config;
    [SerializeField] private Text _text;
    
    public void Show()
    {
        CancelAnimation();
        _windowTransform.localScale = Vector3.zero;
        _windowTransform.gameObject.SetActive(true);

        var seq = DOTween.Sequence();
        seq.SetUpdate(true);
        seq.Append(_windowTransform.DOScale(1f, _config.ScaleTime)
            .SetEase(_config.ScaleEase)
            ).Join(_text.DOText(_text.text, 10f)
            .SetUpdate(true));
        
        PlaySequence(seq);
    }

    public void Hide()
    {
        CancelAnimation();
        _windowTransform.localScale = Vector3.one;
        _windowTransform.gameObject.SetActive(true);

        var seq = DOTween.Sequence();
        seq.SetUpdate(true);
        seq.Append(_windowTransform.DOScale(0f, _config.HideTime)
            .SetEase(_config.HideEase)
            .SetUpdate(true)
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
