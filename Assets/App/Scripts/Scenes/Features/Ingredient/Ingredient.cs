using System.Collections.Generic;
using System.Linq;
using App.Scripts.Libs.Physic;
using App.Scripts.Scenes.Features.Ingredient.Overlap;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Scenes.Features.Ingredient
{
    public class Ingredient : MonoBehaviour
    {
        [SerializeField] private IngredientOverlapChecker _overlapChecker;
    
        public Pizza Pizza { get; private set; }
        public bool IsOverlap { get; private set; }

        public void SetPizza(Pizza pizza)
        {
            Pizza = pizza;
        }

        public void CheckOverlaps(IPhysicsService physics)
        {
            _overlapChecker.TryGetOverlappedIngredients(physics, out IEnumerable<Ingredient> overlapIngredients);
            IsOverlap = overlapIngredients.Any();
        }
    }
}