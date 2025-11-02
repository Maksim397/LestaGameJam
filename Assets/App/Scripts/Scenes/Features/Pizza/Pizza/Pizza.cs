using System;
using System.Collections.Generic;
using App.Scripts.Libs.Physic;
using ModestTree;
using UnityEngine;

namespace App.Scripts.Scenes.Features.PizzaData
{
  public class Pizza : MonoBehaviour
  {
    [SerializeField] private PizzaAnimator _animator;

    private List<Ingredient.Ingredient> _ingredients = new List<Ingredient.Ingredient>();
    
    public IReadOnlyList<Ingredient.Ingredient> Ingredients => _ingredients;
    public bool IsReady => _ingredients.IsEmpty();

    private void Awake()
    {
      _ingredients = new List<Ingredient.Ingredient>(GetComponentsInChildren<Ingredient.Ingredient>());
    }

    private void Start()
    {
      foreach (var ingredient in _ingredients)
      {
        ingredient.SetPizza(this);
      }

      _animator.Show();
    }

    public void UpdateOverlaps(IPhysicsService physics)
    {
      foreach (var ingredient in _ingredients) 
        ingredient.CheckOverlaps(physics);
    }
    
    public void RemoveIngredient(Ingredient.Ingredient ingredient)
    {
      _ingredients.Remove(ingredient);
    }

    public void HideAndDestroy()
    {
       _animator.Hide();
    }
  }
}