using System;
using App.Scripts.Infrastructure.Camera;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Ingredient : MonoBehaviour
{
  private ICameraService _cameraService;

  [Inject]
  private void Construct(ICameraService cameraService)
  {
    _cameraService = cameraService;
  }
  
  private void OnMouseDown()
  {
    Debug.Log("OnBeginDrag");
  }

  private void OnMouseDrag()
  {
    Debug.Log("OnDrag");
  }

  private void OnMouseUp()
  {
    Debug.Log("OnEndDrag");
  }
  
  public void OnPointerUp(PointerEventData eventData)
  {
  }
}
