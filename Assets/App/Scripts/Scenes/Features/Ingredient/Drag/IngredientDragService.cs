using App.Scripts.Infrastructure.Camera;
using UnityEngine;
using Zenject;
using Cysharp.Threading.Tasks;

public class IngredientDragService : ITickable
{
    [SerializeField] private float _UPoffset = 0.1f;

    private float _lockedYpos;
    private IngredientPhysicObject _draggedObject;
    private Vector3 _firstPickPlace;

    private readonly ICameraService _cameraService;
    private readonly Table _table;
    private readonly IIngredientInteractor _interactor;


    IngredientDragService(IIngredientInteractor interactor, ICameraService cameraService, Table table)
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

            if (Physics.Raycast(ray, out RaycastHit hit, 100f, CollisionLayer.PickableIngredient.AsMask()))
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
            StopDragging().Forget();
        }
    }
    

    private void StartDragging(Transform objectToDrag)
    {
        _draggedObject = objectToDrag.GetComponent<IngredientPhysicObject>();
        if (_draggedObject.Ingredient.IsOverlap || _draggedObject.Ingredient.Animator.IsAnimating) 
        { 
            _draggedObject = null; 
            return; 
        }
        
        _draggedObject.SetPhysicActive(false);
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

    private async UniTask StopDragging()
    {
        IngredientPhysicObject objectToStopDragging = _draggedObject;
        _draggedObject = null;

        Ray ray = _cameraService.Camera.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out RaycastHit hit))
        {
            if (objectToStopDragging.gameObject.TryGetComponent<IngredientPhysicObject>(out var physicObject))
            {
                if (!(hit.collider.TryGetComponent<Holder>(out var holder) 
                    && _interactor.TryInteract(physicObject.Ingredient, holder)))
                {
                    await physicObject.Ingredient.Animator.ComebackTo(_firstPickPlace);
                    Debug.Log("JUMP");
                }
            }
            else
            {
                objectToStopDragging.Root.position = _firstPickPlace;
            }
            objectToStopDragging.SetPhysicActive(true);
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
