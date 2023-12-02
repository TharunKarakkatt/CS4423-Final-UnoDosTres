using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{

    public float walkSpeed = 5f;
    public float jumpSpeed = 8f;
    public float airWalkSpeed = 3f;
    public int CheeseMeter;
    TouchingDirections touchingDirections;
    Vector2 moveInput;

    Rigidbody2D rb;
    Animator animator;
    Damageable damageable;

    public float CurrentMoveSpeed { get
        {
            if(CanMove)
            {
                if (IsMoving && !touchingDirections.IsOnWall)
                {
                    if (touchingDirections.IsGrounded)
                    {

                            return walkSpeed;
                    }
                    else
                    {
                        // Air Move
                        return airWalkSpeed;
                    }
                }
                else
                {
                    // Idle speed is 0
                    return 0;
                }
            } else
            {
                // Movement locked
                return 0;
            }
        }
    }

    [SerializeField]
    private bool _isMoving = false;
    public bool IsMoving { get
        {
            return _isMoving;
        }
        private set
        {
            _isMoving = value;

            if(animator != null){
                animator.SetBool("IsMoving", value);
            }
            else
            {
                Debug.LogWarning("Animator not assigned properly");
            }
            
        }
    }

    public bool _isFacingRight = true;
    public bool IsFacingRight { get
        {
            return _isFacingRight;
        }
        private set
        {
            if(_isFacingRight != value)
            {
                transform.localScale *= new Vector2(-1, 1);
            }

            _isFacingRight = value;
        }
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        touchingDirections = GetComponent<TouchingDirections>();
        damageable = GetComponent<Damageable>();
    }

    // Start is called before the first frame update
    void Start()
    {
        CheeseMeter = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if(!IsAlive){

            SceneManager.LoadScene(3);
        }
    }

    private void FixedUpdate()
    {
        if(!damageable.IsHit)
            rb.velocity = new Vector2(moveInput.x * walkSpeed, rb.velocity.y);
        
        animator.SetFloat(AnimationStrings.yVelocity, rb.velocity.y);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();

        if(IsAlive){
            IsMoving = moveInput != Vector2.zero;
            SetFacingDirection(moveInput);
        }
        else{
            IsMoving = false;
        }
        

    }

    private void SetFacingDirection(Vector2 moveInput)
    {
        if(moveInput.x > 0 && !IsFacingRight)
        {
            IsFacingRight = true;
        }
        else if(moveInput.x < 0 && IsFacingRight)
        {
            IsFacingRight = false;
        }
    }

    public void OnAttack(InputAction.CallbackContext context)
    {

        if(context.started && CheeseMeter >= 1)
        {
            animator.SetTrigger(AnimationStrings.OnAttack);
        }
    } 

    public void OnJump(InputAction.CallbackContext context)
    {
        if(context.started && touchingDirections.IsGrounded){
            
            animator.SetTrigger(AnimationStrings.jump);
            rb.velocity = new Vector2(rb.velocity.x, jumpSpeed);
        }
    }

    public bool CanMove { get
        {
            return animator.GetBool(AnimationStrings.canMove);
        }
    }

    public bool IsAlive{
        get{
            return animator.GetBool(AnimationStrings.isAlive);
        }
    }

    public void OnHit(int damage, Vector2 knockback){
        
        rb.velocity = new Vector2(knockback.x, rb.velocity.y + knockback.y);
    }
}
