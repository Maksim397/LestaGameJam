using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Infrastructure.Animator
{
  public class BaseAnimatorTween : MonoBehaviour
  {
    protected Sequence _animation;
    public bool IsAnimating => _animation != null;

    protected UniTask PlaySequenceAsync(Sequence sequence)
    {
      _animation = sequence;

      var tcs = new UniTaskCompletionSource();


      sequence.OnComplete(() => {
        Clear();
        tcs.TrySetResult();
      });
      sequence.OnKill(() => {
        Clear();
        tcs.TrySetResult();
      });

      sequence.Play();

      return tcs.Task;
    }

    protected void PlaySequence(Sequence sequence)
    {
      _animation = sequence;
      
      _animation.OnComplete(Clear);
      _animation.OnKill(Clear);
      
      _animation.Play();
    }
    
     private void Clear() { _animation = null; }

    public void CancelAnimation()
    {
      if (_animation is null) return;

      _animation.Kill(true);
      _animation = null;
    }

    private void OnDestroy()
    {
        CancelAnimation();
    }
  }
}