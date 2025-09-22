using UnityEngine;

/// <summary>
/// Continuously rotates the GameObject this script is attached to.
/// </summary>
public class Spinobject : MonoBehaviour
{
    [Tooltip("The speed at which the object will rotate on each axis.")]
    [SerializeField]
    private Vector3 rotationSpeed = new Vector3(0f, 50f, 0f);

    // Update is called once per frame
    void Update()
    {
        // Rotate the object around its local axes
        // Time.deltaTime ensures the rotation is smooth and frame-rate independent
        transform.Rotate(rotationSpeed * Time.deltaTime);
    }
}