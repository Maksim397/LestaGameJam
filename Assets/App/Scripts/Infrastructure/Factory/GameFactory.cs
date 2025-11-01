using App.Scripts.Libs.Physic;
using App.Scripts.Scenes.Features.Ingredient;
using App.Scripts.Scenes.Features.Level;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    private readonly LevelModel _levelModel;
    private readonly IPhysicsService _physics;

    public GameFactory(LevelModel levelModel, IPhysicsService physics)
    {
      _levelModel = levelModel;
      _physics = physics;
    }
    

    public Pizza CreatePizza(Pizza prefab, Transform parent)
    {
      Pizza pizza = Object.Instantiate(prefab, parent);
      pizza.UpdateOverlaps(_physics);
      _levelModel.SetPizza(pizza);
      
      return pizza;
    }

    public void RemovePizza()
    {
      Object.Destroy(_levelModel.Pizza.gameObject);
      _levelModel.SetPizza(null);
    }
    
    public void RemoveIngredient(Ingredient ingredient)
    {
      var pizza = ingredient.Pizza;
      pizza?.RemoveIngredient(ingredient);
      pizza?.UpdateOverlaps(_physics);
      
      Object.Destroy(ingredient.gameObject);
      
    }
  }
}