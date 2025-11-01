using UnityEngine;
using UnityEngine.UI;

public class GameOverWindow : MonoBehaviour
{
    [SerializeField] private Button _restartButton;
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
        _restartButton.onClick.AddListener(OnRestart);
        _mainMenuButton.onClick.AddListener(OnMainMenu);
    }
    private void OnDestroy()
    {
        _restartButton.onClick.AddListener(OnRestart);
        _mainMenuButton.onClick.RemoveListener(OnMainMenu);
    }
    
  
    private void OnRestart()
    {
    
    }
  
    private void OnMainMenu()
    {
    
    }
    
}
