using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Start is called before the first frame update
   public Transform creature; // Reference to the creature object
    public float smoothTime = 0.3f; // Smoothing time for camera movement
    public float zoomLevel = 7.3f; // Zoom level for the camera

    private Vector3 velocity = Vector3.zero; // Velocity for smoothing

    private void LateUpdate()
    {
        if (creature != null)
        {
            Vector3 targetPosition = new Vector3(creature.position.x, creature.position.y+2, transform.position.z);

            // Smoothly move the camera towards the target position
            transform.position = Vector3.SmoothDamp(transform.position, targetPosition, ref velocity, smoothTime);
        }
    }

    private void Start()
    {
        // Adjust the camera's orthographic size based on the zoom level
        Camera.main.orthographicSize = zoomLevel;
    }
}
