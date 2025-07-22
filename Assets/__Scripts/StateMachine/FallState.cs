using UnityEngine;

public class FallState : IState, ISelfChange
{
    Animator _animator;
    PlayerController _playerController;

    public FallState(Animator animatator, PlayerController playerController)
    {
        this._animator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animator == null || _playerController == null) return;
        _playerController.SpeedY = 0.0f;
    }

    public void Execute()
    {
        if (_playerController == null) return;

        if (_playerController.IsGrounded)
        {
            if(_playerController.AccelerationX > 0.0f)
                SelfChange(new RunRightState(_animator, _playerController));
            else if (_playerController.AccelerationX < 0.0f)
                SelfChange(new RunLeftState(_animator, _playerController));
            else
                SelfChange(new IdleState(_animator, _playerController));
        }
    }

    public void SelfChange(IState state)
    {
        StateManager _stateManager = _playerController.State_Manager;
        if (_stateManager != null)
        {
            _stateManager.ChangeState(state);
        }

    }


    public void Exit()
    {
        if (_animator == null || _playerController == null) return;
    }
}
