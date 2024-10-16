using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    // Create a list to store collectible items
    public List<string> inventoryItems = new List<string>();

    // Method to add item to the inventory
    public void AddItem(string itemName)
    {
        inventoryItems.Add(itemName);
        Debug.Log(itemName + " added to inventory.");
    }

    // Method to display all items in the inventory (for testing)
    public void DisplayInventory()
    {
        Debug.Log("Inventory: ");
        foreach (var item in inventoryItems)
        {
            Debug.Log(item);
        }
    }
}
