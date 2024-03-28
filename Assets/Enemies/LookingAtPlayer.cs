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

            Vector3 direction = player.transform.position - transform.position;
            direction.z = 0f; 

            float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
    }
}
