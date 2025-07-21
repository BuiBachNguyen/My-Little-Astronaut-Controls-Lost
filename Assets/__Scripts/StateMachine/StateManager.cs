using UnityEngine;

public class StateManager : MonoBehaviour
{

    [SerializeField] IState _currentState;

    public IState CurrentState
    { get => _currentState; set => _currentState = value; }

    void Update()
    {
        if (_currentState != null)
            _currentState.Execute();
    }

    public void ChangeState(IState state)
    {
        if (_currentState != null && _currentState == state) return;

        if (_currentState != null)
            _currentState.Exit();

        _currentState = state;

        if (_currentState != null)
            _currentState.Enter();
    }
    public IState GetCurrentState()
    {
        return _currentState;
    }

    public bool IsCurrentState<T>() where T : IState
    {
        return _currentState is T;
    }
}
