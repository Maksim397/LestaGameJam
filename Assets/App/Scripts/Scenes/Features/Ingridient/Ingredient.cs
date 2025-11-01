using System.Collections.Generic;
using App.Scripts.Libs;
using App.Scripts.Scenes.Features.PizzaData;
using UnityEngine;

public class Ingredient : MonoBehaviour
{
    public Pizza Pizza { get; private set; }
    
    [SerializeField] private HorizontalDragObject _horizontalDragObject;
    [SerializeField] private TriggerObserver OverlapObserver;
    
    private readonly List<Ingredient> _overlapIngredients = new List<Ingredient>();
    
    public bool IsOverlap => _overlapIngredients.Count > 0;

    private void Start()
    {
        _horizontalDragObject.OnDrop += OnDrop;
        OverlapObserver.TriggerEnter += OnIngredientOverlapEnter;
        OverlapObserver.TriggerExit += OnIngredientOverlapExit;
    }

    private void OnDestroy()
    {
        _horizontalDragObject.OnDrop -= OnDrop;
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
    
    private void OnDrop(GameObject hitObject)
    {
        if (hitObject.TryGetComponent<Container>(out var container)) 
            container.IngridientDropped(gameObject);
    }
}