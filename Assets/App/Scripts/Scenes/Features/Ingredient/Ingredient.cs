using System.Collections.Generic;
using App.Scripts.Libs.Physic;
using App.Scripts.Scenes.Features.Ingredient.Overlap;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Scenes.Features.Ingredient
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private IngredientOverlapChecker _overlapChecker;
    
        private List<Ingredient> _overlapIngredients = new List<Ingredient>();
        
        public Pizza Pizza { get; private set; }
    
        public bool IsOverlap => _overlapIngredients.Count > 0;

        public void SetPizza(Pizza pizza)
        {
            Pizza = pizza;
        }

        public void CheckOverlaps(IPhysicsService physics)
        {
            if(_overlapChecker.TryGetOverlappedIngredients(physics, out IEnumerable<Ingredient> overlapIngredients))
                _overlapIngredients = new List<Ingredient>(overlapIngredients);
        }
    }
}