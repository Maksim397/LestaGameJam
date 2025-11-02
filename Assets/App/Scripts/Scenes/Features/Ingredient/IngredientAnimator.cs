using System;
using UnityEngine;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class IngredientAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _ingredientTransform;

    [SerializeField] private Config _config;

    public async UniTask ComebackTo(Vector3 positionToReturn)
    {
        CancelAnimation();

        var seq = DOTween.Sequence();
        seq.Append(_ingredientTransform.DOJump(positionToReturn, _config.JumpStrenght, 1, _config.JumpTime)).SetEase(Ease.Linear)
            .Join(_ingredientTransform
                    .DOLocalRotate(new Vector3(0, 150, 360 * _config.JumpFlips), _config.JumpTime, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear));

        await PlaySequenceAsync(seq);
    }

    public async UniTask FallTarget(Transform target)
    {
        CancelAnimation();
        Vector3 startPos = _ingredientTransform.position;
        UnityEngine.Random.Range();

        var seq = DOTween.Sequence();
        seq.Append(_ingredientTransform.DOJump(startPos - new Vector3(0, 0.3f, 0), _config.JumpStrenght, 1, _config.JumpTime)).SetEase(Ease.Linear)
            .Join(_ingredientTransform
                    .DOLocalRotate(new Vector3(0, 0, 360 * _config.JumpFlips), _config.JumpTime, RotateMode.FastBeyond360)
                    .SetEase(Ease.Linear));

        await PlaySequenceAsync(seq);
    }

    [Serializable]
    public class Config
    {
        public float JumpStrenght = 0.3f;
        public float JumpTime = 0.5f;
        public int JumpFlips = 4;
    }
}
