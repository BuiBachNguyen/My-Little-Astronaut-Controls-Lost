using UnityEngine;
using System;

public class PlayerController : MonoBehaviour
{
    //Field for Component
    [SerializeField] Collider2D _collier;
    [SerializeField] Rigidbody2D _rigidbody;
    [SerializeField] Animator _animator;
    [SerializeField] StateManager _stateManager;

    //Field for Var
    [SerializeField] bool readyForClimb;
    [SerializeField] bool isUpStairs; //Upstarir will go down
    [SerializeField] bool isClimbing;
    [SerializeField] bool isDead;
    [SerializeField] float speedX;
    [SerializeField] float accelerationX;
    [SerializeField] float speedY;
    //[SerializeField] float accelerationY;
    [SerializeField] float cdJump;
    [SerializeField] bool isGrounded;

    #region GET-SET

    public StateManager State_Manager { get => _stateManager; }
    public bool ReadyForClimb { get => readyForClimb; set => readyForClimb = value; }
    public bool IsUpStairs { get => isUpStairs; set => isUpStairs = value; }
    public bool IsClimbing { get => isClimbing; set => isClimbing = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public float SpeedX { get => speedX; set => speedX = value; }
    public float AccelerationX { get => accelerationX; set => accelerationX = value; }
    public float SpeedY { get => speedY; set => speedY = value; }
    //public float AccelerationY { get => accelerationY; set => accelerationY = value; }
    public bool IsGrounded { get => isGrounded; set => isGrounded = value; }

    public float CdJump { get => cdJump; set => cdJump = value; }
    #endregion

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        _collier = GetComponent<Collider2D>();
        _rigidbody = GetComponent<Rigidbody2D>();
        _stateManager = GetComponent<StateManager>();
        _animator = GetComponentInChildren<Animator>();


        //Subcribe to ButtonEvents
        ButtonController.Instance.OnClimbPressed += Climb;
        ButtonController.Instance.OnLeftButtonPressed += Left;
        ButtonController.Instance.OnRightButtonPressed += Right;
        ButtonController.Instance.OnJumpButtonPressed += Jump;

        _stateManager.ChangeState(new IdleState(_animator, this));
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        cdJump += Time.deltaTime;
        Flip();
        UpdatePosition();
        Debug.Log(_collier.isTrigger.ToString());

        _animator.SetBool("isDead", IsDead);
        _animator.SetBool("isClimbing", IsClimbing);
        _animator.SetFloat("directionX", Math.Abs(SpeedX));
        _animator.SetFloat("directionY", _rigidbody.linearVelocityY);
    }

    private void UpdatePosition()
    {
        this.transform.position += new Vector3(speedX * Time.deltaTime, speedY * Time.deltaTime, 0);
    }

    private void Flip()
    {
        if (speedX >= 0.1)
        {
            Vector3 Oscale = transform.localScale;
            Oscale.x = 1;
            transform.localScale = Oscale;
        }
        else if (speedX <= -0.1)
        {
            Vector3 Oscale = transform.localScale;
            Oscale.x = -1;
            transform.localScale = Oscale;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Ground))
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Ground))
        {
            IsGrounded = true;
        }
    }
    private void OnCollisionExit2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag(Tag.Ground))
        {
            IsGrounded = false;
        }    
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Ladder))
        {
            Vector2 stairPos = collision.transform.position;
            Vector2 playerPos = transform.position;

            if (readyForClimb == false)
            {
                if (playerPos.y < stairPos.y - 0.1f)
                {
                    isUpStairs = false;
                }
                else
                {
                    isUpStairs = true;
                }
            }
            if (readyForClimb == false)
            {
                if (playerPos.x - stairPos.x <= 0.5f)
                {
                    readyForClimb = true;
                }
            }
        }
        else if (collision.gameObject.CompareTag(Tag.Ground))
        {
            Debug.Log("set ?");
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag(Tag.Ladder))
        {
            readyForClimb = false;
        }
    }

    //Fuct Out to ex
    private void Climb(bool value)
    {
        if (value == true && readyForClimb)
        {
            if (!isUpStairs)
                _stateManager.ChangeState(new ClimbUpState(_animator, this));
            else
                _stateManager.ChangeState(new ClimbDownState(_animator, this));
        }
        else
        {
            _stateManager.ChangeState(new IdleState(_animator, this));
        }
    }
    private void Left(bool value)
    {
        if (isClimbing == true) return;
        if (value == true)
        {
            _stateManager.ChangeState(new RunLeftState(_animator, this));
        }
        else
        {
            _stateManager.ChangeState(new IdleState(_animator, this));
        }
    }

    private void Right(bool value)
    {
        if (isClimbing == true) return;
        if (value == true)
        {
            _stateManager.ChangeState(new RunRightState(_animator, this));
        }
        else
        {
            _stateManager.ChangeState(new IdleState(_animator, this));
        }
    }

    private void Jump(bool value)
    {
        if (isClimbing == true) return;
        if (value == true && isGrounded && !isClimbing)
        {
            _stateManager.ChangeState(new JumpState(_animator, this));
        }
    }


}