using System;
using App.Scripts.Infrastructure.Camera;
using UnityEngine;
using Zenject;
public class HorizontalDragObject : MonoBehaviour
{
  [SerializeField] private Transform _root;
  
  [SerializeField] private float _UPoffset = 0.1f;
  [SerializeField] private float _minX = -2.514f;
  [SerializeField] private float _maxX = 0.423f;
  [SerializeField] private float _minZ = -3.421f;
  [SerializeField] private float _maxZ = -2.124f;

  private ICameraService _cameraService;
  private float _lockedYpos;

  public event Action<GameObject> OnDrop;

  [Inject]
  private void Construct(ICameraService cameraService)
  {
    _cameraService = cameraService;
  }
    
  private void OnMouseDown()
  {
    _lockedYpos = _root.position.y;
  }

  private void OnMouseDrag()
  {
    Vector3 nextPosition = GetMouseOnPlanePos() + new Vector3(0, _UPoffset, 0);

    nextPosition.x = Mathf.Clamp(nextPosition.x, _minX, _maxX);
    nextPosition.z = Mathf.Clamp(nextPosition.z, _minZ, _maxZ);

    _root.position = nextPosition;
  }

  private void OnMouseUp()
  {
    _root.position = new Vector3(_root.position.x, _lockedYpos, _root.position.z);

    Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);
    if (Physics.Raycast(ray, out RaycastHit hit))
    {
      OnDrop?.Invoke(hit.collider.gameObject);
    }
  }


  private Vector3 GetMouseOnPlanePos()
  {
    Plane plane = new Plane(Vector3.up, new Vector3(0, _lockedYpos, 0));
    Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);

    if (plane.Raycast(ray, out float dist)) return ray.GetPoint(dist);
    return new Vector3(0, 0, 0);
  }
}