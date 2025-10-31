using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Libs.LoadingScreen
{
  public class LoadingCurtain : MonoBehaviour
  {
    [SerializeField] private CanvasGroup _curtain;

    private void Awake()
    {
      DontDestroyOnLoad(this);
    }

    public void Show()
    {
      gameObject.SetActive(true);
      _curtain.alpha = 1;
    }

    public void Hide() => DoFadeIn().Forget();

    private async UniTaskVoid DoFadeIn()
    {
      while (_curtain.alpha > 0)
      {
        _curtain.alpha -= 0.03f;
        await UniTask.Delay(30);
      }

      gameObject.SetActive(false);
    }
  }
}