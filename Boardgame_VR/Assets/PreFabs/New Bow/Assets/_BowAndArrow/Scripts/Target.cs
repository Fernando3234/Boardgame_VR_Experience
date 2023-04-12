using UnityEngine;

public class Target : MonoBehaviour, IArrowHittable
{
    public float forceAmount = 1.0f;   // Amount of force to apply to target upon hit
    public Material otherMaterial = null;  // New material to apply to target upon hit
    //public int maxScore = 10; // maximum score for hitting bullseye
    //public float maxDistance = .0f; // maximum distance from center
    public float health = 1f;
    public int score = 0;

    

    void Update()
    {

        healthBar();
    }

    //private bool hasHitTarget = false; // flag to prevent multiple collisions with the same target

    // Implementing the Hit method from the IArrowHittable interface
    public void Hit(Arrow arrow) {
        ApplyMaterial();    // Apply new material to target
        ApplyForce(arrow);  // Apply force to target
        DisableCollider(arrow); // Disable the collider on the arrow to prevent further collisions
        health--;
        score++;
        Debug.Log(score);

    }

    //Give Target a "Health Bar"
    private void healthBar ()
    {
        if (health <= 0f){
            Destroy(gameObject);
        }
    }

    // Apply new material to target
    private void ApplyMaterial()
    {
        if (TryGetComponent(out MeshRenderer meshRenderer))   // Check if target has a MeshRenderer component
            meshRenderer.material = otherMaterial;    // Apply the new material to the target's MeshRenderer
    }

    // Apply force to target upon hit
    private void ApplyForce(Arrow arrow)
    {
        if (TryGetComponent(out Rigidbody rigidbody))   // Check if target has a Rigidbody component
            rigidbody.AddForce(arrow.transform.forward * forceAmount);   // Apply force in the direction of the arrow's forward vector
    }

    // Disable the collider on the arrow to prevent further collisions
    private void DisableCollider(Arrow arrow)
    {
        if (arrow.TryGetComponent(out Collider collider)) // Check if arrow has a Collider component
            collider.enabled = false;   // Disable the collider on the arrow
    }
}
