using System;
using UnityEngine;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using Cysharp.Threading.Tasks;

public class HolderAnimator : BaseAnimatorTween
{
    [SerializeField] private Transform _holderViewTransform;

    [SerializeField] private Config _config;

    public void Punch()
    {
        CancelAnimation();

        var seq = DOTween.Sequence();
        seq.Append(_holderViewTransform.DOPunchPosition(new Vector3(0, -_config.PunchStrenght, 0), _config.PunchTime, _config.PunchVibration));

        PlaySequence(seq);
    }
    
    [Serializable]
    public class Config
    {
        public float PunchTime = 0.5f;
        public int PunchVibration = 10;
        public float PunchStrenght = 0.05f;
    }
}
