
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InGameWindow : MonoBehaviour
{
    [SerializeField] public Button _pauseButton;
    [SerializeField] public TMP_Text _timer;
    public void Show()
    {
        gameObject.SetActive(true);
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }
    
    void Start()
    {
        _pauseButton.onClick.AddListener(OnPause);
    }

    private void OnDestroy()
    {
        _pauseButton.onClick.RemoveListener(OnPause);
    }

    private void OnPause()
    {
        
    }

    void Update()
    {
        
    }
}
