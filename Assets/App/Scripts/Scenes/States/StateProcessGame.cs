using System.Collections.Generic;
using App.Scripts.Infrastructure.Factory;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Libs;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.Features.Level;
using App.Scripts.Scenes.Features.Level.Data;
using App.Scripts.Scenes.Features.PizzaData;
using Cysharp.Threading.Tasks;
using UnityEngine;

namespace App.Scripts.Scenes.States
{
  public class StateProcessGame : GameState
  {
    private readonly LevelModel _levelModel;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticData;
    private readonly PizzaContainer _pizzaContainer;

    private List<Pizza> PizzaVariantsByCollectedAmount(int collectedAmount) => LevelData.Pizzas[collectedAmount].Variants;
    private int CollectedPizzas => _levelModel.CollectedPizzas;

    //TODO: refactor to many levels
    private LevelData LevelData => _staticData.Levels.Data[0];

    public StateProcessGame(LevelModel levelModel, IGameFactory gameFactory, IStaticDataService staticData, 
      PizzaContainer pizzaContainer)
    {
      _levelModel = levelModel;
      _gameFactory = gameFactory;
      _staticData = staticData;
      _pizzaContainer = pizzaContainer;
    }
    
    public override void OnEnterState()
    {
      SpawnPizza();
    }

    public override void Tick()
    {
      if (_levelModel.Pizza == false)
        return;

      if (_levelModel.Pizza.IsReady)
      {
        Debug.Log("Pizza is ready!"); 

        RemovePizza();
        _levelModel.IncreaseCollectedPizzas();

        if (CollectedPizzas >= LevelData.Pizzas.Count)
        {
          _levelModel.SetLevelResult(LevelResult.Win);
          StateMachine.ChangeState<StateGameEnd>();
          return;
        }
        
        SpawnPizzaWithDelay(1000).Forget();
      }
    }

    private async UniTaskVoid SpawnPizzaWithDelay(int spawnDelay)
    {
      await UniTask.Delay(spawnDelay);
      SpawnPizza();
    }
    
    private Pizza SpawnPizza() => 
      _gameFactory.CreatePizza(
      PizzaVariantsByCollectedAmount(CollectedPizzas).PickRandom(),
      _pizzaContainer.transform);

    private void RemovePizza() =>_gameFactory.RemovePizza();
  }
}