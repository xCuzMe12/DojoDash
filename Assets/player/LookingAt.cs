using UnityEngine;

public class LookingAt : MonoBehaviour
{
    private Camera mainCam;

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
            Vector3 mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);

            // Calculate rotation towards mouse position
            Vector3 direction = mousePos - transform.position;
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply rotation only if there's a significant change in direction
            if (direction.magnitude > 0.2f)
            {
                Quaternion rotation = Quaternion.AngleAxis(angle, Vector3.forward);
                transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * 10f);
            }
        }
    }
}