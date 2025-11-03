using App.Scripts.Infrastructure.UIMediator;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindow : MonoBehaviour
{
    [SerializeField] private UiMediator _uiMediator;
    [SerializeField] private TutorialWindowAnimator _animator;
    
    [SerializeField] private Button _continueButton;

    private void Start()
    {
        Show();
        _continueButton.onClick.AddListener(OnContinue);
    }

    public void Show()
    {
        _animator.Show();
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        _animator.Hide();
    }

    private void OnContinue()
    {  
        Hide();
    }
}
