using System.Collections.Generic;
using UnityEngine;

namespace App.Scripts.Scenes.Features.PizzaData
{
  public class Pizza : MonoBehaviour
  {
    private List<Ingredient> _ingredients = new List<Ingredient>();
    
    public IReadOnlyList<Ingredient> Ingredients => _ingredients;

    private void Awake()
    {
      _ingredients = new List<Ingredient>(GetComponentsInChildren<Ingredient>());
    }
    
    public void RemoveIngredient(Ingredient ingredient)
    {
      _ingredients.Remove(ingredient);
    } 
  }
}