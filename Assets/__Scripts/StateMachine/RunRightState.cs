using System;
using UnityEngine;

public class RunRightState : IState
{
    Animator _animator;
    PlayerController _playerController;

    public RunRightState(Animator animatator, PlayerController playerController)
    {
        this._animator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animator == null || _playerController == null) return;
        _playerController.SpeedX = 0;
        _playerController.AccelerationX = 0.15f;
    }

    public void Execute()
    {
        _playerController.SpeedX += _playerController.AccelerationX;
        _playerController.SpeedX = Math.Max(-Constraint.MAX_SPEED, _playerController.SpeedX);
    }

    public void Exit()
    {
        if (_animator == null || _playerController == null) return;
    }
}
