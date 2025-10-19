using UnityEngine;
using UnityEngine.SceneManagement; // Required namespace for scene management

/// <summary>
/// This script reloads the currently active scene when the 'r' key is pressed.
/// </summary>
public class SceneReloader : MonoBehaviour
{
    // Update is called once per frame
    void Update()
    {
        // Check if the user pressed the "r" key down this frame
        if (Input.GetKeyDown(KeyCode.R))
        {
            // Get the build index of the currently active scene
            int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

            // Reload the scene using its build index
            SceneManager.LoadScene(currentSceneIndex);
        }
    }
}