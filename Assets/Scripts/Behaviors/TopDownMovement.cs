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

    private void Awake()
    {
        movementController = GetComponent<TopDownController>();
        movementRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponentInChildren<Animator>();
    }

    void Start()
    {
        movementController.OnMoveEvent += Move;
        movementController.OnJumpEvent += Jump;
    }

    private void FixedUpdate()
    {
        if (isJump)
        {
            float speed = 8;

            movementRigidbody.velocity = Vector2.zero;
            movementRigidbody.AddForce(Vector2.up * speed, ForceMode2D.Impulse);

            animator.SetBool("IsJumping", true);

            if (movementRigidbody.velocity.y < -2)
            {
                Debug.DrawRay(movementRigidbody.position, Vector3.down, new Color(0, 1, 0));
                RaycastHit2D rayHit = Physics2D.Raycast(movementRigidbody.position, Vector3.down, -3f, LayerMask.GetMask("Platform"));
                if (rayHit.collider != null)
                {
                    if (rayHit.distance > -2f)
                    {
                        animator.SetBool("IsJumping", false);
                    }

                }

            }


        }

        ApplyMovement(movementDirection);




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
