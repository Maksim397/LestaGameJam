using Cysharp.Threading.Tasks;
using DG.Tweening;
using UnityEngine;

namespace App.Scripts.Infrastructure.Animator
{
  public class BaseAnimatorTween : MonoBehaviour
  {
    protected Sequence _animation;
    public bool IsAnimating => _animation != null;

    protected UniTask PlaySequenceAsync(Sequence seq)
    {
      _animation = seq;

      var tcs = new UniTaskCompletionSource();

      void Clear() { _animation = null; }

      seq.OnComplete(() => {
        Clear();
        tcs.TrySetResult();
      });
      seq.OnKill(() => {
        Clear();
        tcs.TrySetResult();
      });

      seq.Play();

      return tcs.Task;
    }

    public void CancelAnimation()
    {
      if (_animation is null) return;

      _animation.Kill(true);
      _animation = null;
    }
  }
}