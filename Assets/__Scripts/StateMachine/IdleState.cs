using UnityEngine;

public class IdleState : IState
{
    Animator _animatator;
    PlayerController _playerController;

    public IdleState(Animator animatator, PlayerController playerController)
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
        _playerController.IsClimbing = false;
        _playerController.AccelerationX = 0;
        _playerController.AccelerationY = 0;
        _playerController.SpeedX = 0;
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }
}