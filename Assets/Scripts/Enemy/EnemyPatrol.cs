using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyPatrol : MonoBehaviour
{
    public float moveSpeed = 3f;           // Speed at which the enemy moves
    public float patrolRangeX = 5f;        // Patrol range on the X axis
    public float patrolRangeY = 3f;        // Patrol range on the Y axis
    public float directionChangeInterval = 2f;  // Time interval to change direction
    public float detectionRange = 1.5f; // Distance at which the enemy can spot the player
    public Transform player; // Reference to the player's transform

    private Vector3 initialPosition;
    private Vector3[] patrolPoints;
    private int currentPointIndex = 0;
    private float timeToChangeDirection;
    private bool isPlayerSpotted = false; // Whether the player has been spotted

    void Start()
    {
        initialPosition = transform.position;

        // Define the four corners of the rectangle based on patrol ranges
        patrolPoints = new Vector3[4];
        patrolPoints[0] = initialPosition + new Vector3(patrolRangeX, patrolRangeY, 0);  // Top-right
        patrolPoints[1] = initialPosition + new Vector3(patrolRangeX, -patrolRangeY, 0); // Bottom-right
        patrolPoints[2] = initialPosition + new Vector3(-patrolRangeX, -patrolRangeY, 0); // Bottom-left
        patrolPoints[3] = initialPosition + new Vector3(-patrolRangeX, patrolRangeY, 0);  // Top-left

        timeToChangeDirection = Time.time + directionChangeInterval;
    }

    void Update()
    {
        // Move towards the current patrol point
        transform.position = Vector3.MoveTowards(transform.position, patrolPoints[currentPointIndex], moveSpeed * Time.deltaTime);

        // Check if the enemy has reached the current patrol point
        if (transform.position == patrolPoints[currentPointIndex])
        {
            // Update to the next patrol point (loop back to the start after reaching the last point)
            currentPointIndex = (currentPointIndex + 1) % patrolPoints.Length;
        }

        // Change direction at a set interval
        if (Time.time >= timeToChangeDirection)
        {
            timeToChangeDirection = Time.time + directionChangeInterval;
        }

        if (isPlayerSpotted)
        {
            return; // Stop patrolling if the player is spotted
        }

        DetectPlayer();
    }

    void DetectPlayer()
    {
        if (player == null) return; // Exit if no player reference

        // Calculate the distance to the player
        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= detectionRange)
        {
            isPlayerSpotted = true;
            Debug.Log("player spotted");
            GameOver();
        }
    }

    void GameOver()
    {
        // Handle Game Over logic here, e.g., load the Game Over scene.
        SceneManager.LoadScene("Caught");
    }

    void OnDrawGizmosSelected()
    {
        // Draw the detection range in the Scene view
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, detectionRange);
    }
}
