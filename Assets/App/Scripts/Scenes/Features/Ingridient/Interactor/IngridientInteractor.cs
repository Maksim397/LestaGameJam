using UnityEngine;

public class IngridientInteractor : IIngridientInteractor
{
    public void Interact(Ingredient ingredient, Holder holder)
    {
        if (holder is Trash) 
        {
            Debug.Log("trash thrown");
            GameObject.Destroy(ingredient.gameObject);
        }
        else if (holder is Bowl)
        {
            Debug.Log("food in bowl: " + holder.gameObject.name);
            GameObject.Destroy(ingredient.gameObject);
        }
        
    }
}
