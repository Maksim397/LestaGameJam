using System;
using System.Collections.Generic;
using App.Scripts.Libs.StateMachine;
using Cysharp.Threading.Tasks;
using Zenject;
public class GameStateMachine : ITickable
{
  private readonly Dictionary<Type, GameState> _states = new();
  private GameState _currentState;
  private bool _isTransitioning;
  private GameState _queued;

  public GameStateMachine(IEnumerable<GameState> states)
  {
    foreach (var s in states) AddState(s);
  }

  public UniTask ChangeStateAsync<T>() where T : GameState =>
    ProcessChangeStateAsync(_states[typeof(T)]);

  public void ChangeState<T>() where T : GameState =>
    ChangeStateAsync<T>().Forget(); // удобный шорткат

  public void Tick() => _currentState?.Tick();

  private void AddState(GameState state)
  {
    state.StateMachine = this;
    _states[state.GetType()] = state;
  }

  private async UniTask ProcessChangeStateAsync(GameState next)
  {
    if (_isTransitioning) { _queued = next; return; }
    _isTransitioning = true;

    _currentState?.OnExitState();
    _currentState = next;
    _currentState.OnEnterState();
    await _currentState.OnEnterStateAsync();

    _isTransitioning = false;

    if (_queued != null)
    {
      var q = _queued; _queued = null;
      await ProcessChangeStateAsync(q);
    }
  }
}