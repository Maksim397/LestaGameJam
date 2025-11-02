using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetNameWindow : MonoBehaviour
{
    [SerializeField] private Button _acceptButton;
    [SerializeField] private TMP_InputField _inputField;

    public void Show() => gameObject.SetActive(true);
    public void Hide() => gameObject.SetActive(false);

    private void Start() => _acceptButton.onClick.AddListener(OnAcceptName);

    private void OnDestroy() => _acceptButton.onClick.RemoveListener(OnAcceptName);

    private void OnAcceptName()
    {
        //Validation and return name logic
    }
}
