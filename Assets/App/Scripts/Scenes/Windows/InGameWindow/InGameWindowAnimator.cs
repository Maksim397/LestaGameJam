using System;
using App.Scripts.Infrastructure.Animator;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameWindowAnimator : BaseAnimatorTween
{
  [SerializeField] private Transform _textTransform;
  [SerializeField] private TMP_Text _text;
  [SerializeField] private Config _config;
  [SerializeField] private Transform _buttonTransform;
  public void ScaleTime()
  {
    CancelAnimation();
    Color originalColor = _text.color;
    var seq = DOTween.Sequence();
    seq.Append(_textTransform.DOPunchScale(_config.Punch, _config.PunchTime, _config.PunchVibrato, _config.PunchElasticity));
    seq.Join(_text.DOColor(Color.red, 0.5f).SetLoops(2, LoopType.Yoyo));
    
    PlaySequence(seq);
  }
  
  [Serializable]
  public class Config
  {
    public Vector3 Punch = new Vector3(0.1f, 0.1f, 0.1f);
    public float PunchTime = 1f;
    public int PunchVibrato = 10;
    public float PunchElasticity = 1f;
    
    public float ScaleTime = 0.8f;
    public Ease ScaleEase = Ease.OutBack;
    public float HideTime = 0.4f;
    public Ease HideEase = Ease.InBack;
  }

  public void Show()
  {
    ShowButton();
  }
  
  public void Hide()
  {
    HideButton();
  }

  public void ShowButton()
  {
    CancelAnimation();
    
    _buttonTransform.localScale = Vector3.zero;
    _buttonTransform.gameObject.SetActive(true);
    
   
    var seq = DOTween.Sequence();
    seq.SetUpdate(true);
    seq.Append(_buttonTransform.DOScale(1f, _config.ScaleTime)
      .SetEase(_config.ScaleEase)
      .SetUpdate(true));
    
    PlaySequence(seq);
  }

  public void HideButton()
  {
    CancelAnimation();
    _buttonTransform.localScale = Vector3.one;
    _buttonTransform.gameObject.SetActive(true);
        
    var seq = DOTween.Sequence();
    seq.SetUpdate(true);
    seq.Append(_buttonTransform.DOScale(0f, _config.HideTime)
      .SetEase(_config.HideEase)
      .SetUpdate(true)
      .OnComplete(() => _buttonTransform.gameObject.SetActive(false))
      );
        
    PlaySequence(seq);
  }
}
