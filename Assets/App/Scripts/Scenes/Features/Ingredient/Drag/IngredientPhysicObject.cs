using UnityEngine;

public class IngredientPhysicObject : MonoBehaviour
{
  [field: SerializeField] public Ingredient Ingredient { get; private set; }
  [field: SerializeField] public Transform Root { get; private set; }
}