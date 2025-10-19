/// <summary>
/// Controls the player's movement, including a sprinting mechanic.
/// Attach this script to your player GameObject.
/// The GameObject must have a CharacterController component.
/// </summary>
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    // [SerializeField] exposes private variables in the Unity Inspector
    // without making them public to other scripts.

    /// <summary>
    /// The player's standard movement speed.
    /// </summary>
    [SerializeField]
    private float moveSpeed = 5.0f;

    /// <summary>
    /// The multiplier applied to the move speed when sprinting.
    /// </summary>
    [SerializeField]
    private float sprintMultiplier = 1.5f;

    // Update is called once per frame
    void Update()
    {
        // --- Input Handling ---
        // Get input from the default Horizontal and Vertical axes (WASD or Arrow Keys)
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Create a direction vector based on the input
        Vector3 moveDirection = new Vector3(horizontalInput, 0f, verticalInput);

        // --- Speed Calculation ---
        // Start with the base move speed
        float currentSpeed = moveSpeed;

        // Check if the Left Shift key is being held down
        if (Input.GetKey(KeyCode.LeftShift))
        {
            // If sprinting, apply the sprint multiplier
            currentSpeed *= sprintMultiplier;
        }

        // --- Apply Movement ---
        // Calculate the final movement vector by multiplying direction, speed, and Time.deltaTime.
        // Time.deltaTime makes the movement frame-rate independent.
        Vector3 movement = moveDirection * currentSpeed * Time.deltaTime;

        // Apply the movement to the player's position
        transform.Translate(movement);
    }
}