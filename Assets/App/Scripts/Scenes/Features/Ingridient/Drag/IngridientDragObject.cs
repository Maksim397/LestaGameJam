using UnityEngine;

public class IngridientDragObject : MonoBehaviour
{
  [field: SerializeField] public IngridientDragObject Ingridient { get; private set; }
  [field: SerializeField] public Transform Root { get; private set; }
}