using UnityEngine;

public class ClimbDownState : IState, ISelfChange
{
    Animator _animator;
    PlayerController _playerController;

    public ClimbDownState(Animator animatator, PlayerController playerController)
    {
        this._animator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animator == null || _playerController == null) return;
        Rigidbody2D rig = _playerController.GetComponent<Rigidbody2D>();
        rig.gravityScale = 0f;
    }

    public void Execute()
    {
        _playerController.IsClimbing = true;
        _playerController.SpeedY = -1;
        Collider2D _col = _playerController.GetComponent<Collider2D>();
        _col.isTrigger = true;
        if (!_playerController.ReadyForClimb)
        {
            _col.isTrigger = false;
            SelfChange(new IdleState(_animator, _playerController));
        }
    }

    public void Exit()
    {
        if (_animator == null || _playerController == null) return;
        Rigidbody2D rig = _playerController.GetComponent<Rigidbody2D>();
        rig.gravityScale = 2f;
        _playerController.SpeedY = 0;
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
