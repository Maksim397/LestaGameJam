using App.Scripts.Scenes.Features.Ingredient;
using UnityEngine;

public class IngredientPhysicObject : MonoBehaviour
{
  [field: SerializeField] public Ingredient Ingredient { get; private set; }
  [field: SerializeField] public Transform Root { get; private set; }
  
  [SerializeField] private Collider _collider;
  
  public void SetPhysicActive(bool isActive) => _collider.enabled = isActive;
}