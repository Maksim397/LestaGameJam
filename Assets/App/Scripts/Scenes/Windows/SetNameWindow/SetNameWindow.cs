using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetNameWindow : MonoBehaviour
{
    [SerializeField] private Button _acceptButton;
    [SerializeField] private TMP_InputField _inputField;
    [SerializeField] private SetNameWindowAnimator _animator;
    private UniTaskCompletionSource<string> _completionSource;

    public UniTask<string> Show()
    {
        _animator.Show();
      _completionSource = new UniTaskCompletionSource<string>();
      gameObject.SetActive(true);
      
      return _completionSource.Task;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        _animator.Hide();
    }

    private void Start() => _acceptButton.onClick.AddListener(OnAcceptName);

    private void OnDestroy() => _acceptButton.onClick.RemoveListener(OnAcceptName);

    private void OnAcceptName()
    {
        if (_inputField.text.Length != 0)
        {
            SetResult(_inputField.text);
        }
    }

    private void SetResult(string result)
    {
      _completionSource.TrySetResult(result);
      Hide();
    }
}
