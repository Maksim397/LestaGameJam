using System.Collections.Generic;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Infrastructure.Factory
{
  public class GameFactory : IGameFactory
  {
    public IEnumerable<ISavedProgress> ProgressWriters { get; }
    
    public GameFactory()
    {
      
    }

    public Pizza CreatePizza(Pizza prefab, Transform parent)
    {
      Pizza pizza = Object.Instantiate(prefab, parent);
      return pizza;
    }
  }
}