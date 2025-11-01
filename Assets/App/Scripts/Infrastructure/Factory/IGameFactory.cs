using System.Collections.Generic;
using App.Scripts.Infrastructure.PersistentProgress;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Infrastructure.Factory
{
  public interface IGameFactory
  {
    IEnumerable<ISavedProgress> ProgressWriters { get; }
    Pizza CreatePizza(Pizza prefab, Transform parent);
  }
}