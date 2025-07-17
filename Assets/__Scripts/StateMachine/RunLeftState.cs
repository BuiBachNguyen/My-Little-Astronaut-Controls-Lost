using System;
using UnityEngine;

public class RunLeftState : IState
{
    Animator _animatator;
    PlayerController _playerController;

    public RunLeftState(Animator animatator, PlayerController playerController)
    {
        this._animatator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animatator == null || _playerController == null) return;
        _playerController.SpeedX = 0;
        _playerController.AccelerationX = 0.25f;
    }

    public void Execute()
    {
        _playerController.SpeedX -= _playerController.AccelerationX;
        _playerController.SpeedX = Math.Min(-Constraint.MAX_SPEED, _playerController.SpeedX);
        Debug.Log(_playerController.SpeedX);
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }
}
