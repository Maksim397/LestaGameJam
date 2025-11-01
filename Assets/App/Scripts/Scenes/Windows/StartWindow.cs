using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StartWindow : MonoBehaviour
{
    [SerializeField] private Button _startButton;
    [SerializeField] private Button _quitButton;
    
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
        _startButton.onClick.AddListener(OnStart);
        _quitButton.onClick.AddListener(OnQuit);
    }
  
    private void OnDestroy()
    {
        _startButton.onClick.RemoveListener(OnStart);
        _quitButton.onClick.RemoveListener(OnQuit);
    }

    private void OnStart()
    {
        
    }
  
    private void OnQuit()
    {
        
    }
}
