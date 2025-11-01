using App.Scripts.Infrastructure.Factory;
using App.Scripts.Scenes.Features.Ingredient;
using App.Scripts.Scenes.Features.Level;

public class IngredientInteractor : IIngredientInteractor
{
    private readonly IGameFactory _gameFactory;
    public IngredientInteractor(IGameFactory gameFactory)
    {
        _gameFactory = gameFactory;
    }
    
    public void Interact(Ingredient ingredient, Holder holder)
    {
        if (holder is Trash) 
        {
            _gameFactory.RemoveIngredient(ingredient);
        }
        else if (holder is Bowl)
        {
            _gameFactory.RemoveIngredient(ingredient);
        }
    }
}
