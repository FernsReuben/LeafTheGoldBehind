using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;        // Reference to the player's transform
    public Vector3 offset;          // Offset from the player position

    void Update()
    {
        if (player != null)
        {
            // Update the camera position to follow the player with the offset
            transform.position = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);
        }
    }
}
