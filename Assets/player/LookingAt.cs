using UnityEngine;

public class LookingAt : MonoBehaviour
{
    private Camera mainCam;
    [HideInInspector] public Vector3 mousePos;

    public float rotationThreshold = 0.2f; // Threshold for significant change in direction
    public float rotationSpeed = 10f; // Speed of rotation

    private Quaternion targetRotation; // Rotation to smoothly interpolate towards

    void Start()
    {
        mainCam = Camera.main; // This automatically finds the main camera
    }

    void Update()
    {
        // Check if the main camera is available
        if (mainCam != null)
        {
            // Get mouse position in world coordinates
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            // Calculate rotation towards mouse position
            Vector3 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Check if the change in direction is significant
            if (direction.magnitude > rotationThreshold)
            {
                targetRotation = Quaternion.AngleAxis(angle, Vector3.forward);
            }

            // Smoothly interpolate towards the target rotation
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * rotationSpeed);
        }
    }
}