using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using App.Scripts.Infrastructure.UIMediator;
using Cysharp.Threading.Tasks;
using UnityEngine;
using UnityEngine.UI;

public class TutorialWindow : MonoBehaviour
{
    [SerializeField] private UiMediator _uiMediator;
    [SerializeField] private TutorialWindowAnimator _animator;
    
    [SerializeField] private Button _continueButton;
    
    private UniTaskCompletionSource _completionSource;

    private void Start()
    {
        _continueButton.onClick.AddListener(OnContinue);
    }

    private void OnDestroy()
    {
        _continueButton.onClick.RemoveListener(OnContinue);
    }

    public UniTask Show()
    {
        if (_completionSource != null)
            return _completionSource.Task; // уже показано, вернём текущий таск

        _completionSource = new UniTaskCompletionSource();
        
        _animator.Show();
        gameObject.SetActive(true);
        
        return _completionSource.Task;
    }

    public void Hide()
    {
        _completionSource?.TrySetResult();
        _completionSource = null;
        _animator.Hide();
        gameObject.SetActive(false);
    }

    private void OnContinue()
    {  
        Hide();
    }
}
