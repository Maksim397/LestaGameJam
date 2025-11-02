using System;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using UnityEngine;

public class InGameWindowAnimator : BaseAnimatorTween
{
  [SerializeField] private Transform _textTransform;
  
  [SerializeField] private Config _config;
  
  public void ScaleTime()
  {
    CancelAnimation();

    var seq = DOTween.Sequence();
    seq.Append(_textTransform.DOPunchScale(_config.Punch, _config.PunchTime, _config.PunchVibrato, _config.PunchElasticity));
    
    PlaySequence(seq);
  }
    
  [Serializable]
  public class Config
  {
    public Vector3 Punch = new Vector3(0.1f, 0.1f, 0.1f);
    public float PunchTime = 1f;
    public int PunchVibrato = 10;
    public float PunchElasticity = 1f;
  }
}
