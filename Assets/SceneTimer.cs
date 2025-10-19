using UnityEngine;
using TMPro; // Required for TextMeshPro UI elements

/// <summary>
/// Starts a timer when the scene loads and stops it when a GameObject
/// tagged "Player" enters this object's trigger.
/// </summary>
public class SceneTimer : MonoBehaviour
{
    // Public variable to link your UI Text element
    [Header("UI Elements")]
    public TMP_Text timerText;

    // Private timer variables
    private float elapsedTime;
    private bool isTimerRunning;

    /// <summary>
    /// Called when the script instance is being loaded.
    /// </summary>
    void Start()
    {
        // Initialize the timer
        elapsedTime = 0f;
        isTimerRunning = true;
    }

    /// <summary>
    /// Called once per frame.
    /// </summary>
    void Update()
    {
        // Only increment the time if the timer is running
        if (isTimerRunning)
        {
            elapsedTime += Time.deltaTime;
            UpdateTimerDisplay();
        }
    }

    /// <summary>
    /// Formats the elapsed time and updates the UI text.
    /// </summary>
    private void UpdateTimerDisplay()
    {
        // Calculate minutes, seconds, and milliseconds
        int minutes = (int)(elapsedTime / 60);
        int seconds = (int)(elapsedTime % 60);
        int milliseconds = (int)((elapsedTime * 1000) % 1000);

        // Format the string as MM:SS:FFF (e.g., 01:23:456)
        // "D2" ensures two digits (padding with a 0 if needed)
        // "D3" ensures three digits (padding with 0s if needed)
        timerText.text = string.Format("{0:D2}:{1:D2}:{2:D3}", minutes, seconds, milliseconds);
    }

    /// <summary>
    /// Called when another Collider enters this object's trigger.
    /// </summary>
    /// <param name="other">The Collider that entered the trigger.</param>
    private void OnTriggerEnter(Collider other)
    {
        // Check if the timer is running AND the object that entered is the Player
        if (isTimerRunning && other.CompareTag("Player"))
        {
            // Stop the timer
            isTimerRunning = false;

            // Log the final time to the Unity console
            Debug.Log($"Finished! Final Time: {elapsedTime}");

            // Perform one final update to the display to show the exact stop time
            UpdateTimerDisplay();
        }
    }
}