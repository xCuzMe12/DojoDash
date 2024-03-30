using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(menuName = "Abilities/CrossbowTurret")]
public class CrossbowTurret : Ability
{
    public GameObject TurretPrefab;
    public float spawnDistance = 5f; // Distance ahead of the player to spawn the turret

    public override void Activate(GameObject player)
    {
        // Get the position of the mouse cursor in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is 0 (on the ground)

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mousePosition - player.transform.position;
        direction.Normalize(); // Normalize the direction vector

        // Calculate the spawn position a few units ahead of the player
        Vector3 spawnPosition = player.transform.position + direction * spawnDistance;

        // Instantiate the turret at the calculated spawn position
        Instantiate(TurretPrefab, spawnPosition, Quaternion.identity);
    }
}
