using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.Physic;
using UnityEngine;
using Zenject;

namespace App.Scripts.Scenes.Features.Ingredient.Overlap
{
  public class IngredientOverlapChecker : MonoBehaviour
  {
    [SerializeField] private Ingredient _ingredient;
    [SerializeField] private SphereCollider _collider;
    
    

    private float ColliderWorldScale => _collider.radius * transform.lossyScale.x;
    
    public bool TryGetOverlappedIngredients(IPhysicsService physics, out IEnumerable<Ingredient> overlappedIngredients)
    {
      overlappedIngredients = physics
        .OverlapCircle<IngredientPhysicObject>(_collider.bounds.center, ColliderWorldScale, Physics.AllLayers)
        .Select(x => x.Ingredient)
        .Where(x => x != _ingredient);
      
      return overlappedIngredients.Any();
    }
  }
}