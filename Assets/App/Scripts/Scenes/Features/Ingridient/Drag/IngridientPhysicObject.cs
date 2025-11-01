using UnityEngine;

public class IngridientPhysicObject : MonoBehaviour
{
  [field: SerializeField] public Ingredient Ingredient { get; private set; }
  [field: SerializeField] public Transform Root { get; private set; }
}