using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TopDownMovement : MonoBehaviour
{
    private TopDownController movementController;
    private Rigidbody2D movementRigidbody;
    [SerializeField] private SpriteRenderer characterRenderer;
    protected Animator animator;
    private static readonly int IsWalking = Animator.StringToHash("IsWalking");
    private readonly float magnituteThreshold = 0.5f;
    private static readonly int IsJumping = Animator.StringToHash("IsJumping");

    private bool isJump;
    private Vector2 movementDirection = Vector2.zero;
    private Vector2 lastDirection = Vector2.right;

    private bool doJump;
    private float jumptime = 1.0f;


    private void Awake()
    {
        movementController = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
        //animator = GetComponent<Animator>();
    }

    void Start()
    {
        movementController.OnMoveEvent += Move;
        movementController.OnJumpEvent += Jump;
    }

    private void FixedUpdate()
    {

        if (isJump && doJump == false && !animator.GetBool(IsJumping))
        {
            doJump = true;
            float speed = 10;

            movementRigidbody.velocity = Vector2.zero;
            movementRigidbody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);
       
            animator.SetBool(IsJumping, true);
            Invoke("JumpDelay", jumptime);
        }

        ApplyMovement(movementDirection);
    }

    private void JumpDelay()
    {
        doJump = false;
        animator.SetBool(IsJumping, false);
    }

    private void Move(Vector2 direction)
    {
        movementDirection = direction;

        if (direction.magnitude > magnituteThreshold)
        {
            lastDirection = direction;
        }
 
        animator.SetBool(IsWalking, direction.magnitude > magnituteThreshold);
      
    }

    private void Jump(bool jump)
    {
        //if(!isJump)
        isJump = jump;
    }

    private void ApplyMovement(Vector2 direction)
    {
        // 이동 속도 조절
        float speed = 5.0f;

        Vector2 newPosition = direction * speed;

        movementRigidbody.velocity = new Vector2(newPosition.x, movementRigidbody.velocity.y);

        if (direction.magnitude > magnituteThreshold)
        {
            characterRenderer.flipX = direction.x < 0;
        }
        else
        {
            characterRenderer.flipX = lastDirection.x < 0;
        }

    }



}
