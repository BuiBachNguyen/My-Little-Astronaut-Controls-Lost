using UnityEngine;

public class IdleState : IState
{
    Animator _animator;
    PlayerController _playerController;

    public IdleState(Animator animatator, PlayerController playerController)
    {
        this._animator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animator == null || _playerController == null) return;
    }

    public void Execute()
    {
        _playerController.IsClimbing = false;
        _playerController.AccelerationX = 0;
        _playerController.SpeedX = 0;
    }

    public void Exit()
    {
        if (_animator == null || _playerController == null) return;
    }
}