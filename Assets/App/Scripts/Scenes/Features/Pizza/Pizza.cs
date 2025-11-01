using System;
using System.Collections.Generic;
using ModestTree;
using UnityEngine;

namespace App.Scripts.Scenes.Features.PizzaData
{
  public class Pizza : MonoBehaviour
  {
    private List<Ingredient> _ingredients = new List<Ingredient>();
    
    public IReadOnlyList<Ingredient> Ingredients => _ingredients;
    public bool IsReady => _ingredients.IsEmpty();

    private void Awake()
    {
      _ingredients = new List<Ingredient>(GetComponentsInChildren<Ingredient>());
    }

    private void Start()
    {
      foreach (var ingredient in _ingredients)
      {
        ingredient.SetPizza(this);
      }
    }
    
    public void RemoveIngredient(Ingredient ingredient)
    {
      _ingredients.Remove(ingredient);
    }
  }
}