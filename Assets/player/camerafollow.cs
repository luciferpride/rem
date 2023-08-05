using UnityEngine;

public class camerafollow : MonoBehaviour
{
    public Transform target; // Reference to the player's transform
    public Vector3 cameraOffset = new Vector3(0f, 10f, -10f); // Camera offset from the player

    private void Update()
    {
        if (target != null)
        {
            // Calculate the new camera position based on the player's position and the offset
            Vector3 newPosition = target.position + cameraOffset;

            // Set the camera's position
            transform.position = newPosition;

            // Make the camera look at the player
            transform.LookAt(target.position);
        }
    }
}
