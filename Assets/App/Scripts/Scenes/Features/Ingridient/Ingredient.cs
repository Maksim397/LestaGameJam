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
        if (collideObject.TryGetComponentInParent<Ingredient>(out var ingredient)) 
            _overlapIngredients.Add(ingredient);
    }
    
    private void OnIngredientOverlapExit(Collider collideObject)
    {
        if (collideObject.TryGetComponentInParent<Ingredient>(out var ingredient) 
            && _overlapIngredients.Contains(ingredient)) 
            _overlapIngredients.Remove(ingredient);
    }
}