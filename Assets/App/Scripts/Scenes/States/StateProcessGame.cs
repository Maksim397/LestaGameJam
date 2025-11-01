using System.Collections.Generic;
using App.Scripts.Infrastructure.Factory;
using App.Scripts.Infrastructure.StaticData;
using App.Scripts.Libs;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.Features.Level;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

namespace App.Scripts.Scenes.States
{
  public class StateProcessGame : GameState
  {
    private readonly LevelModel _levelModel;
    private readonly IGameFactory _gameFactory;
    private readonly IStaticDataService _staticData;
    
    private List<Pizza> PizzaVariantsForLevel(int level) => LevelData.Pizzas[level].Variants;

    //TODO: refactor to many levels
    private LevelData LevelData => _staticData.Levels.Data[0];

    public StateProcessGame(LevelModel levelModel, IGameFactory gameFactory, IStaticDataService staticData)
    {
      _levelModel = levelModel;
      _gameFactory = gameFactory;
      _staticData = staticData;
    }
    
    public override void OnEnterState()
    {
      // int level = _levelModel.CollectedPizzas;
      // _gameFactory.CreatePizza(_levelModel.Pizza, PizzaVariantsForLevel(level).PickRandom().transform);
    }
    
    public override void Tick()
    {
      // if (_levelModel.Pizza.IsReady)
      // {
      //   Debug.Log("Pizza is ready!");
      // }
    }
  }
}