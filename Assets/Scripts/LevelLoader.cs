using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelLoader : MonoBehaviour
{
    // Method to load a specific level by name
    public void LoadLevel(string levelName)
    {
        SceneManager.LoadScene(levelName);
    }

    // Exit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}
