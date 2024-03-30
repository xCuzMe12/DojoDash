using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/MegaBullet")]
public class MegaBullet : Ability
{
    public GameObject BulletPrefab;
    public float spawnDistance;


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
        Instantiate(BulletPrefab, spawnPosition, Quaternion.identity);
    }

    Vector3 GetMouseWorldPosition()
    {
        // Get the mouse position in screen coordinates
        Vector3 mousePosition = Input.mousePosition;
        mousePosition.z = -Camera.main.transform.position.z;

        // Convert the screen coordinates to world coordinates
        return Camera.main.ScreenToWorldPoint(mousePosition);
    }
}
