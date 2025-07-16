using UnityEngine;

public class JumpState : IState, ISelfChange
{
    Animator _animatator;
    PlayerController _playerController;

    public JumpState(Animator animatator, PlayerController playerController)
    {
        this._animatator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animatator == null || _playerController == null) return;
    }

    public void Execute()
    {
        Debug.Log(this.GetType().ToString());
        _playerController.IsClimbing = false;
        _playerController.IsDead = false;
        _playerController.AccelerationX = 0;
        _playerController.AccelerationY = 0;
        _playerController.SpeedX = 0;
        _playerController.SpeedY = 2;
        _playerController.JumppedTime += Time.deltaTime;

        if (_playerController.JumppedTime >= 1.25f)
        {
            SelfChange(new FallState(_animatator, _playerController));
        }    
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }

    public void SelfChange(IState state)
    {
        StateManager _stateManager = _playerController.State_Manager;
        if (_stateManager != null)
        {
            _stateManager.ChangeState(state);
        } 
            
    }
}
