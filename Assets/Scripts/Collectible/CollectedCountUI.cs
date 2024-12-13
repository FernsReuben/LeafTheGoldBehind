using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class CollectedCountUI : MonoBehaviour
{
    public TextMeshProUGUI collectedCountText; // Reference to the Text UI element
    private int collectedCount = 0; // Local counter for collected items

    // Method to update the count on the UI
    public void UpdateCount(int count)
    {
        collectedCount = count;
        collectedCountText.text = $": {collectedCount}";
        if(collectedCount == 3) {
        SceneManager.LoadScene("Win"); 
    }
    }
}
