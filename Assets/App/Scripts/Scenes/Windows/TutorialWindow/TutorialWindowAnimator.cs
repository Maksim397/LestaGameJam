using System;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindowAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _windowTransform;
    [SerializeField] private Text _text;
    [SerializeField] private Config _config;

    private string _cachedFullText;
    
    public void Show()
    {
        CancelAnimation();
        _windowTransform.localScale = Vector3.zero;
        _windowTransform.gameObject.SetActive(true);

        _cachedFullText = _text.text;
        _text.text = string.Empty;

        float typeDuration = Mathf.Max(0.01f, _cachedFullText.Length / _config.CharsPerSecond);
        var seq = DOTween.Sequence();
        seq.SetUpdate(true);

        seq.Append(_windowTransform
                .DOScale(1f, _config.ScaleTime)
                .SetEase(_config.ScaleEase)
                .SetUpdate(true))
           .Join(_text.DOText(_cachedFullText, typeDuration, _config.RichText).SetUpdate(true));

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
        public float CharsPerSecond = 30f;
        public bool RichText;
    }
}
