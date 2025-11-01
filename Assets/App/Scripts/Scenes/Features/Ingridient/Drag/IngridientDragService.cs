using App.Scripts.Infrastructure.Camera;
using System;
using UnityEngine;
using Zenject;
using App.Scripts.Libs;

public class IngridientDragService : ITickable
{
    private LayerMask _pickableLayerMask = LayerMask.GetMask("IngridientDragObject");
    [SerializeField] private float _UPoffset = 0.1f;

    private float _lockedYpos;
    private IngridientPhysicObject _draggedObject;
    private Vector3 _firstPickPlace;

    private readonly ICameraService _cameraService;
    private readonly Table _table;
    private readonly IIngridientInteractor _interactor;


    IngridientDragService(IIngridientInteractor interactor, ICameraService cameraService, Table table)
    {
        _interactor = interactor;
        _cameraService = cameraService;
        _table = table;
    }

    public void Tick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, _pickableLayerMask))
            {
                StartDragging(hit.transform);
            }
        }

        if (_draggedObject != null)
        {
            Drag();
        }

        if (Input.GetMouseButtonUp(0) && _draggedObject != null)
        {
            StopDragging();
        }
    }
    

    private void StartDragging(Transform objectToDrag)
    {
        _draggedObject = objectToDrag.GetComponent<IngridientPhysicObject>();
        if (_draggedObject.Ingredient.IsOverlap) 
        { 
            _draggedObject = null; 
            return; 
        }
        _lockedYpos = _draggedObject.Root.position.y;
        _firstPickPlace = _draggedObject.Root.position;
    }

    private void Drag()
    {
        Vector3 nextPosition = GetMouseOnPlanePos() + new Vector3(0, _UPoffset, 0);

        Bounds tableBounds = _table.Collider.bounds;

        nextPosition.x = Mathf.Clamp(nextPosition.x, tableBounds.min.x, tableBounds.max.x);
        nextPosition.z = Mathf.Clamp(nextPosition.z, tableBounds.min.z, tableBounds.max.z);

        _draggedObject.Root.position = nextPosition;
    }

    private void StopDragging()
    {
        _draggedObject.Root.position = _firstPickPlace;

        Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (hit.collider.TryGetComponent<Holder>(out var holder)
                && _draggedObject.gameObject.TryGetComponent<IngridientPhysicObject>(out var physicObject))
            {
                _interactor.Interact(physicObject.Ingredient, holder);
            }
        }

        _draggedObject = null;
    }


    private Vector3 GetMouseOnPlanePos()
    {
        Plane plane = new Plane(Vector3.up, new Vector3(0, _lockedYpos, 0));
        Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);

        if (plane.Raycast(ray, out float dist)) return ray.GetPoint(dist);
        return new Vector3(0, 0, 0);
    }
}
