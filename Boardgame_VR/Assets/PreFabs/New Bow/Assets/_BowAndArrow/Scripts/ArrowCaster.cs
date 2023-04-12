using UnityEngine; // Import the Unity Engine library

public class ArrowCaster : MonoBehaviour // Define the ArrowCaster class as a MonoBehaviour
{
    [SerializeField] private Transform tip; // Declare a private Transform variable called "tip" that can be set in the Inspector window
    [SerializeField] private LayerMask layerMask = ~0; // Declare a private LayerMask variable called "layerMask" that can be set in the Inspector window, and initialize it with all layers

    private Vector3 lastPosition = Vector3.zero; // Declare a private Vector3 variable called "lastPosition" and initialize it with a zero vector

    public bool CheckForCollision(out RaycastHit hit) // Declare a public method called "CheckForCollision" that returns a boolean value and takes an out parameter of type RaycastHit
    {
        if (lastPosition == Vector3.zero) // Check if lastPosition is zero
            lastPosition = tip.position; // Set lastPosition to the position of the tip

        bool collided = Physics.Linecast(lastPosition, tip.position, out hit, layerMask); // Check for collisions between lastPosition and tip.position, and store the information about the collision in the "hit" variable. The "collided" variable is set to true if a collision occurred.

        lastPosition = collided ? lastPosition : tip.position; // If a collision occurred, set lastPosition to its current value. Otherwise, set it to the position of the tip.

        return collided; // Return the value of the "collided" variable
    }
}