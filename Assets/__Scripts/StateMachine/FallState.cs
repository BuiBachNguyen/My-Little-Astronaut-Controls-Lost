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
    }

    public void Execute()
    {
        Debug.Log(this.GetType().ToString());
        _playerController.IsClimbing = false;
        _playerController.IsDead = false;
        _playerController.AccelerationX = 0;
        _playerController.AccelerationY = 0;
        _playerController.SpeedX = 0;
        _playerController.SpeedY = -2;
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }
}
