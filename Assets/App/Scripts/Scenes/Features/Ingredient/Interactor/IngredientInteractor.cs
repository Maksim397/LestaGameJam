using App.Scripts.Infrastructure.Factory;
using App.Scripts.Scenes.Features.Ingredient;
using App.Scripts.Infrastructure.UIMediator;
using App.Scripts.Libs.StateMachine;
using App.Scripts.Scenes.Features.Level;
using App.Scripts.Scenes.Features.Level.Data;
using App.Scripts.Scenes.States;
using Cysharp.Threading.Tasks;
using UnityEngine;

public class IngredientInteractor : IIngredientInteractor
{
    private readonly IGameFactory _gameFactory;
    private readonly UiMediator _uiMediator;
    private readonly GameStateMachine _gameStateMachine;
    private readonly LevelModel _levelModel;

    private int _secondsToRemove = 10;

    public IngredientInteractor(IGameFactory gameFactory, UiMediator uiMediator, 
        GameStateMachine gameStateMachine, LevelModel levelModel)
    {
        _gameFactory = gameFactory;
        _uiMediator = uiMediator;
        _gameStateMachine = gameStateMachine;
        _levelModel = levelModel;
    }
    
    public bool TryInteract(Ingredient ingredient, Holder holder)
    {
        if (holder is Trash)
        {
            if (ingredient.State == IngredientState.FRESH)
            {
                _uiMediator.RemoveTime(System.TimeSpan.FromSeconds(_secondsToRemove));
            }
            //_gameFactory.RemoveIngredient(ingredient, holder.transform.position);
            RemoveIngredient(ingredient, holder).Forget();

            return true;
        }
        else if (holder is Bowl bowl)
        {
            if (bowl.Type == ingredient.Type)
            {
                if (ingredient.State != IngredientState.FRESH) 
                {
                    _levelModel.SetLevelResult(LevelResult.Loose);
                    _gameStateMachine.ChangeState<StateGameEnd>();
                }
                //_gameFactory.RemoveIngredient(ingredient, holder.transform.position);
                RemoveIngredient(ingredient, holder).Forget();
                return true;
            }
            else
            {
                _uiMediator.RemoveTime(System.TimeSpan.FromSeconds(_secondsToRemove));
            }
        }

        return false;
    }

    private async UniTask RemoveIngredient(Ingredient ingredient, Holder holder)
    {
        _gameFactory.RemoveIngredient(ingredient);
        await ingredient.Animator.FallTarget(holder.transform.position);
        Object.Destroy(ingredient.gameObject);
        holder.Animator.Punch();
    }
}
