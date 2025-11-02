using App.Scripts.Scenes.Features.Ingredient;
public interface IIngredientInteractor
{
    bool TryInteract(Ingredient ingredient, Holder holder);
}
