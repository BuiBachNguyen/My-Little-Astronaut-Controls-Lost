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
        //if (_playerController.JumppedTime >= Constraint.MAX_JUMP_TIME) return;

        _playerController.AccelerationY = 0.15f;
        _playerController.SpeedY = 1.5F;
        _playerController.JumppedTime = 0;
        _playerController.CdJump = Constraint.MAX_JUMP_TIME;
        // Jump Eff
        // _playerController.PlayJumpEffect();
    }

    public void Execute()
    {
        _playerController.SpeedY += _playerController.AccelerationY;
        _playerController.SpeedY = Mathf.Max(_playerController.SpeedY, Constraint.MAX_JUMP_SPEED);

        _playerController.JumppedTime += Time.deltaTime;

        if (_playerController.JumppedTime >= Constraint.MAX_JUMP_TIME)
        {
            SelfChange(new FallState(_animatator, _playerController));
        }
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
        _playerController.JumppedTime = Constraint.MAX_JUMP_TIME;

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
