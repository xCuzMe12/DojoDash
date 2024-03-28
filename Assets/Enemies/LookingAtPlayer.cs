using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookingAtPlayer : MonoBehaviour
{
    GameObject player;

    void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        if (player != null)
        {
            // Get direction from enemy to player
            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0f; // Ensure the direction is in the XY plane

            // Calculate the angle to rotate towards the player
            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            // Apply the rotation
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
