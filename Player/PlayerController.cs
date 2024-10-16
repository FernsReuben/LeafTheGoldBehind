using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Speed of the player movement

    private Rigidbody2D rb;       // Reference to the player's Rigidbody2D component
    private Vector2 moveDirection;  // Direction of movement
    private Animator animator;    // Animator component

    // Track the last movement direction to face that direction when idle
    private Vector2 lastMoveDirection;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Get the Rigidbody2D component
        animator = GetComponent<Animator>(); // Get the Animator component
    }

    void Update()
    {
        // Get input for movement (WASD or arrow keys)
        float moveX = Input.GetAxisRaw("Horizontal");  // Left (-1) or Right (1)
        float moveY = Input.GetAxisRaw("Vertical");    // Up (1) or Down (-1)

        // Store movement direction
        moveDirection = new Vector2(moveX, moveY).normalized;

        // Update animator parameters based on movement
        if (moveDirection != Vector2.zero)
        {
            animator.SetFloat("moveX", moveX);  // Set horizontal parameter
            animator.SetFloat("moveY", moveY);  // Set vertical parameter

            // Store the last move direction so we know where the player was facing
            lastMoveDirection = moveDirection;
        }

        // Handle idle state
        animator.SetBool("isMoving", moveDirection != Vector2.zero);

        // If idle, keep the last facing direction
        if (moveDirection == Vector2.zero)
        {
            animator.SetFloat("lastMoveX", lastMoveDirection.x);
            animator.SetFloat("lastMoveY", lastMoveDirection.y);
        }
    }

    void FixedUpdate()
    {
        // Move the player by applying velocity
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }
}
