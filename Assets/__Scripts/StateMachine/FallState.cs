using UnityEngine;

public class FallState : IState
{
    Animator _animatator;
    PlayerController _playerController;

    public FallState(Animator animatator, PlayerController playerController)
    {
        this._animatator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animatator == null || _playerController == null) return;
        _playerController.SpeedY = 0.0f;
    }

    public void Execute()
    {
        _playerController.AccelerationY = 0.15f;
        _playerController.SpeedY -=_playerController.AccelerationY;
        _playerController.SpeedY =Mathf.Min(-Constraint.MAX_FALLING, _playerController.SpeedY);
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }
}
