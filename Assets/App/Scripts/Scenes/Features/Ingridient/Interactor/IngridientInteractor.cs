using UnityEngine;

public class IngridientInteractor : IIngridientInteractor
{
    public void Interact(Ingredient ingredient, Holder holder)
    {
        if (holder is Trash) 
        {
            if (ingredient.Pizza != null) 
                ingredient.Pizza.RemoveIngredient(ingredient);
            
            GameObject.Destroy(ingredient.gameObject);
        }
        else if (holder is Bowl)
        {
            if (ingredient.Pizza != null) 
                ingredient.Pizza.RemoveIngredient(ingredient);
            
            GameObject.Destroy(ingredient.gameObject);
        }
    }
}
