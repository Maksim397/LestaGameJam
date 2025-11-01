using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class WinWindow : MonoBehaviour
{
    [SerializeField] private Button _mainMenuButton;
    
    public void Show()
    {
        gameObject.SetActive(true);
    }
    public void Hide()
    {
        gameObject.SetActive(false);
    }
    private void Start()
    {
        _mainMenuButton.onClick.AddListener(OnMainMenu);
    }
    private void OnDestroy()
    {
        _mainMenuButton.onClick.RemoveListener(OnMainMenu);
    }
    private void OnMainMenu()
    {
    
    }
  
    private void OnRestart()
    {
    
    }
  
}
