using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public string itemName; // Name of the item to be added to inventory
    private static int collectedCount = 0; // Static counter for all collected items

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is the player (raccoon)
        if (collision.CompareTag("Player"))
        {
            // Find the player's inventory and add the item
            Inventory playerInventory = collision.GetComponent<Inventory>();
            if (playerInventory != null)
            {
                // Add the item to the inventory
                playerInventory.AddItem(itemName);

                // Increment the counter
                collectedCount++;

                // Update the UI
                var uiController = FindObjectOfType<CollectedCountUI>();
                if (uiController != null)
                {
                    uiController.UpdateCount(collectedCount);
                }

                // Destroy the collectible after it has been picked up
                Destroy(gameObject);
            }
        }
    }

    public static void ResetCount(){
        collectedCount = 0;
    }
}
