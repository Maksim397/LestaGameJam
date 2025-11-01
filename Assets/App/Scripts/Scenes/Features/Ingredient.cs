using System;
using App.Scripts.Infrastructure.Camera;
using UnityEngine;
using UnityEngine.EventSystems;
using Zenject;

public class Ingredient : MonoBehaviour
{
    private ICameraService _cameraService;
    private Camera _mainCamera;

    private float _lockedYpos;
    [Header("Перемещение и ограничения")]
    [SerializeField] private float _UPoffset = 0.1f; //На сколько поднимаются продукты
    [SerializeField] private float _minX = -2.514f;
    [SerializeField] private float _maxX = 0.423f;
    [SerializeField] private float _minZ = -3.421f;
    [SerializeField] private float _maxZ = -2.124f;



    [Inject]
    private void Construct(ICameraService cameraService)
    {
        _cameraService = cameraService;
        _mainCamera = _cameraService.Camera;
    }
  
    private void OnMouseDown()
    {
        Debug.Log("OnBeginDrag");
        _lockedYpos = transform.position.y;
    }

    private void OnMouseDrag()
    {
        Vector3 nextPosition = GetMouseOnPlanePos() + new Vector3(0, _UPoffset, 0);
        //применям ограничения
        nextPosition.x = Mathf.Clamp(nextPosition.x, _minX, _maxX);
        nextPosition.z = Mathf.Clamp(nextPosition.z, _minZ, _maxZ);

        transform.position = nextPosition;
    }

    private void OnMouseUp()
    {
        Debug.Log("OnEndDrag");
        transform.position = new Vector3(transform.position.x, _lockedYpos, transform.position.z);

        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            Container container = hit.collider.GetComponent<Container>();
            if (container != null) //-------------------------НАЙДЕН КОНТЕЙНЕР-------------------
            {
                Debug.Log("Found container: " + hit.collider.name);
                Destroy(gameObject);
            }                      //-------------------------------------------------------------
        }
    }


    private Vector3 GetMouseOnPlanePos()
    {
        Plane plane = new Plane(Vector3.up, new Vector3(0, _lockedYpos, 0));
        Ray ray = _mainCamera.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float dist)) return ray.GetPoint(dist);
        return new Vector3(0, 0, 0);
    }
}
