using System;
using System.Collections.Generic;
using Cysharp.Threading.Tasks;

namespace App.Scripts.Libs.StateMachine
{
  public class GameStateMachine
  {
    private readonly Dictionary<Type, GameState> _states = new Dictionary<Type, GameState>();
    private GameState _currentState;
    private GameState _stateToChange;

    public GameStateMachine(IEnumerable<GameState> states)
    {
      foreach (var state in states)
        AddState(state);
    }

    public void ChangeState<T>()
    {
      var stateType = typeof(T);
      if (_states.TryGetValue(stateType, out var state)) _stateToChange = state;
    }

    public void Tick()
    {
      CheckSwitchState();

      _currentState?.Tick();
    }

    private void AddState(GameState state)
    {
      state.StateMachine = this;
      _states[state.GetType()] = state;
    }

    private void CheckSwitchState()
    {
      if (_stateToChange is null) return;

      var nextState = _stateToChange;
      _stateToChange = null;

      ProcessChangeState(nextState);
    }

    private void ProcessChangeState(GameState value)
    {
      ExitState();

      _currentState = value;
      _currentState.OnEnterState();
      _currentState.OnEnterStateAsync().Forget();
    }

    private void ExitState()
    {
      if (_currentState is null) return;

      _currentState.OnExitState();
    }
  }
}