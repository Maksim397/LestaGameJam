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
    private readonly PizzaContainer _pizzaContainer;

    private List<Pizza> PizzaVariantsByCollectedAmount(int collectedAmount) => _levelModel.LevelData.Pizzas[collectedAmount].Variants;
    private int CollectedPizzas => _levelModel.CollectedPizzas;
    
    public StateProcessGame(LevelModel levelModel, IGameFactory gameFactory, PizzaContainer pizzaContainer)
    {
      _levelModel = levelModel;
      _gameFactory = gameFactory;
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

        RemovePizza(false);
        _levelModel.IncreaseCollectedPizzas();

        if (CollectedPizzas >= _levelModel.LevelData.Pizzas.Count)
        {
          _levelModel.SetLevelResult(LevelResult.Win);
          StateMachine.ChangeState<StateGameEnd>();
          return;
        }
        
        SpawnPizzaWithDelay(1000).Forget();
      }
    }
    
    public override void OnExitState()
    {
      RemovePizza(true);
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

    private void RemovePizza(bool isLoose) =>_gameFactory.RemovePizza(isLoose);
  }
}