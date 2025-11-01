using App.Scripts.Scenes.Features.Level.Data;
using App.Scripts.Scenes.Features.PizzaData;

namespace App.Scripts.Scenes.Features.Level
{
  public class LevelModel
  {
    public int CollectedPizzas { get; private set; }
    public Pizza Pizza { get; private set; }
    public LevelResult LevelResult { get; private set; }
    
    public void Reset()
    {
      CollectedPizzas = 0;
      Pizza = null;
      LevelResult = LevelResult.Unknown;
    }

    public void SetLevelResult(LevelResult levelResult) => LevelResult = levelResult;
    public void SetPizza(Pizza pizza) => Pizza = pizza;
    public void IncreaseCollectedPizzas() => CollectedPizzas++;
  }
}