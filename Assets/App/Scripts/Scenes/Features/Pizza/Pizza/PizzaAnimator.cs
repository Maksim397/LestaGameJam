using System;
using App.Scripts.Infrastructure.Animator;
using UnityEngine;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class PizzaAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _pizzaTransform;
    [SerializeField] private Transform _pizzaViewTransform;

    [SerializeField] private Config _config;

    public void Show()
    {
        CancelAnimation();
        Vector3 startPosition = _pizzaTransform.position;

        var seq = DOTween.Sequence();
        seq.Append(_pizzaTransform.DOMoveY(startPosition.y, _config.FallTime)
                   .From(startPosition.y + _config.UpOffset)
                   .SetEase(_config.FallEase));

        PlaySequence(seq);
    }

    public async UniTask Hide()
    {
        CancelAnimation();

        var seq = DOTween.Sequence();
        seq.Append(_pizzaViewTransform.DOScale(0f, _config.HideTime)
            .SetEase(_config.HideEase));

        await PlaySequenceAsync(seq);
    }

    public async UniTask HideWithIngredients()
    {
        CancelAnimation();

        var seq = DOTween.Sequence();
        seq.Append(_pizzaTransform.DOScale(0f, _config.HideTime)
            .SetEase(_config.HideEase));

        await PlaySequenceAsync(seq);
    }

    [Serializable]
    public class Config
    {
        public float UpOffset = 1f;
        public Ease FallEase = Ease.OutBounce;
        public float FallTime = 0.8f;
        public Ease HideEase = Ease.InBack;
        public float HideTime = 0.8f;
    }
}
