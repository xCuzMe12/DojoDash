using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/Dash")]
public class Dash : Ability
{
    public float dashVelocity;

    public override void Activate(GameObject player)
    {
        LookingAt pozicija = player.GetComponent<LookingAt>();
        playerMovement movement = player.GetComponent<playerMovement>();
        Rigidbody2D rb = player.GetComponent<Rigidbody2D>();

        if (rb != null && movement != null)
        {
            Debug.Log("V redu");
            Debug.Log(rb.angularDrag);
            Vector2 dashDir = (pozicija.mousePos - (Vector3)player.transform.position).normalized;
            Debug.Log(dashDir);
            Debug.Log(dashVelocity);

            rb.velocity = dashDir * dashVelocity;
            Debug.Log(rb.velocity);
        }
        else
        {
            Debug.Log("Nisi dobil komponent");
        }

    }
}
