using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelTrigger : MonoBehaviour
{
    public string levelName; // Name of the level to load

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Check if the colliding object is tagged as "Player"
        if (collision.CompareTag("Player"))
        {
            // Load the specified level
            SceneManager.LoadScene(levelName);
        }
    }
}
