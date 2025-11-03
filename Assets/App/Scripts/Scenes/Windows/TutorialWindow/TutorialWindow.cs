using System;
using System.Collections;
using System.Collections.Generic;
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
        _continueButton.onClick.AddListener(OnContinue);
    }


    public void Show()
    {
        gameObject.SetActive(true);
        
    }

    public void Hide()
    {
        gameObject.SetActive(false);
    }

    private void OnContinue()
    {
        _uiMediator.StartWindow();
    }
}
