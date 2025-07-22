using UnityEngine;

public class JumpState : IState, ISelfChange
{
    Animator _animator;
    PlayerController _playerController;

    public JumpState(Animator animatator, PlayerController playerController)
    {
        this._animator = animatator;
        _playerController = playerController;
    }
    public void Enter()
    {
        if (_animator == null || _playerController == null) return;
        Rigidbody2D col = _playerController.GetComponent<Rigidbody2D>();
        col.AddForce(Vector2.up * 5f * _playerController.Modifier, ForceMode2D.Impulse);
    }

    public void Execute()
    {
        if (_playerController == null) return;

        Rigidbody2D rb = _playerController.GetComponent<Rigidbody2D>();
        if (rb == null) return;

        if (rb.linearVelocityY <= 0f)
        {
            SelfChange(new FallState(_animator, _playerController));
        }
    }


    public void Exit()
    {
        if (_animator == null || _playerController == null) return;

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
