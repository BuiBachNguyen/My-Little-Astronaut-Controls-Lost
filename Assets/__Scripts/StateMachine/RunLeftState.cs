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
    }

    public void Execute()
    {
        Debug.Log(this.GetType().ToString());
        _playerController.IsClimbing = false;
        _playerController.IsDead = false;
        _playerController.AccelerationX = 0;
        _playerController.AccelerationY = 0;
        _playerController.SpeedX = -1;
        _playerController.SpeedY = -1;
    }

    public void Exit()
    {
        if (_animatator == null || _playerController == null) return;
    }
}
