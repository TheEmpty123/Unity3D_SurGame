using UnityEngine;

public class ObjectDestroyer : MonoBehaviour
{
    public float interactionDistance = 10f; // Max distance for raycasting

    void Update()
    {
        // Check if the player presses the 'E' key
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Perform raycast from the camera's position forward
            Ray ray = new Ray(Camera.main.transform.position, Camera.main.transform.forward);
            RaycastHit hit;

            // Check if the ray hits anything within the interaction distance
            if (Physics.Raycast(ray, out hit, interactionDistance))
            {
                // Check if the hit object has one of the colliders
                if (hit.collider != null && (hit.collider.CompareTag("Item") || hit.collider.CompareTag("Rock")))
                {
                    // Destroy the object
                    Destroy(hit.collider.gameObject);
                }
            }
        }
    }
}
