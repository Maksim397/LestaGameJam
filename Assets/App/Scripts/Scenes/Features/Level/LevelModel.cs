using App.Scripts.Scenes.Features.PizzaData;

namespace App.Scripts.Scenes.Features.Level
{
  public class LevelModel
  {
    public int CollectedPizzas { get; private set; }
    public Pizza Pizza { get; private set; }

    public LevelModel()
    {
      CollectedPizzas = 0;
      Pizza = null;
    }
    
    public void SetPizza(Pizza pizza) => Pizza = pizza;
    public void IncreaseCollectedPizzas() => CollectedPizzas++;
  }
}