using UnityEngine;
using App.Scripts.Scenes.Features.Ingredient;

public class PizzaIngredientShafle : MonoBehaviour
{
    [ContextMenu("«адать случайный поворот всем ингредиентам")]
    private void RandomizeAllIngredientsRotation()
    {
        Ingredient[] allIngredients = GetComponentsInChildren<Ingredient>();

        foreach (Ingredient ingredient in allIngredients)
        {
            Vector3 currentRotation = ingredient.transform.eulerAngles;
            float randomYRotation = Random.Range(0, 360);

            ingredient.transform.eulerAngles = new Vector3(
                currentRotation.x,
                randomYRotation,
                currentRotation.z
            );
        }
    }
}
