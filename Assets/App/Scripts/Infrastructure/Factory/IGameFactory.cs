using System.Collections.Generic;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Scenes.Features.Ingredient;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Infrastructure.Factory
{
  public interface IGameFactory
  {
    Pizza CreatePizza(Pizza prefab, Transform parent);
    void RemovePizza();
    void RemoveIngredient(Ingredient ingredient, Vector3 to);
  }
}