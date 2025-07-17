using UnityEngine;
using UnityEngine.Events;
using System;
using System.Collections.Generic;
using Unity.VisualScripting;

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
    [SerializeField] float accelerationY;
    [SerializeField] float cdJump;
    [SerializeField] float jumppedTime;

    #region GET-SET

    public StateManager State_Manager { get => _stateManager; }
    public bool ReadyForClimb { get => readyForClimb; set => readyForClimb = value; }
    public bool IsUpStairs { get => isUpStairs; set => isUpStairs = value; }
    public bool IsClimbing { get => isClimbing; set => isClimbing = value; }
    public bool IsDead { get => isDead; set => isDead = value; }
    public float SpeedX { get => speedX; set => speedX = value; }
    public float AccelerationX { get => accelerationX; set => accelerationX = value; }
    public float SpeedY { get => speedY; set => speedY = value; }
    public float AccelerationY { get => accelerationY; set => accelerationY = value; }

    public float CdJump { get => cdJump; set => cdJump = value; }
    public float JumppedTime { get => jumppedTime; set => jumppedTime = value; }
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
        _animator.SetFloat("directionY", SpeedY);
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
            if (_stateManager.IsCurrentState<FallState>())
                _stateManager.ChangeState(new IdleState(_animator, this));
            jumppedTime = 0.0f;
            cdJump = 0.0f;
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
            if(readyForClimb == false)
            {
                if(playerPos.x - stairPos.x <= 0.5f)
                {
                    readyForClimb = true;
                }    
            }    
        }
        else if(collision.gameObject.CompareTag(Tag.Ground))
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
        if (value == true)
        {
            cdJump = 0f;
            _stateManager.ChangeState(new JumpState(_animator, this));
        }
        else
        {
            _stateManager.ChangeState(new IdleState(_animator, this));
        }
    }


}