using System.Collections.Generic;
using App.Scripts.Libs;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Pizza Pizza { get; private set; }

    [SerializeField] private TriggerObserver OverlapObserver;
    
    private readonly List<Ingredient> _overlapIngredients = new List<Ingredient>();
    
    public bool IsOverlap => _overlapIngredients.Count > 0;


    private void Start()
    {
        OverlapObserver.TriggerEnter += OnIngredientOverlapEnter;
        OverlapObserver.TriggerExit += OnIngredientOverlapExit;
    }

    private void OnDestroy()
    {
        OverlapObserver.TriggerEnter -= OnIngredientOverlapEnter;
        OverlapObserver.TriggerExit -= OnIngredientOverlapExit;
    }

    public void SetPizza(Pizza pizza)
    {
        Pizza = pizza;
    }

    private void OnIngredientOverlapEnter(Collider collideObject)
    {
        if (collideObject.TryGetComponent<IngridientPhysicObject>(out var physicObject)) 
            _overlapIngredients.Add(physicObject.Ingredient);
    }
    
    private void OnIngredientOverlapExit(Collider collideObject)
    {
        if (collideObject.TryGetComponent<IngridientPhysicObject>(out var physicObject) 
            && _overlapIngredients.Contains(physicObject.Ingredient)) 
            _overlapIngredients.Remove(physicObject.Ingredient);
    }
}