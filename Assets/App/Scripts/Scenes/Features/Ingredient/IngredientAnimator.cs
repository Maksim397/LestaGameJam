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

    public async UniTask FallTarget(Vector3 target)
    {
        CancelAnimation();
        bool rotateByX = UnityEngine.Random.Range(0, 2) == 0;
        float rotateYOn = UnityEngine.Random.Range(0, 360);

        var seq = DOTween.Sequence();
        seq.Append(_ingredientTransform.DOJump(target, _config.JumpStrenght, 1, _config.JumpTime)).SetEase(Ease.Linear)
            .Join(_ingredientTransform
                    .DOLocalRotate(new Vector3(rotateByX ? 360 * _config.JumpFlips : 0, rotateYOn, rotateByX ?  0 : 360 * _config.JumpFlips), 
                                   _config.JumpTime, RotateMode.FastBeyond360)
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
