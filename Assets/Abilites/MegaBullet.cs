using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/MegaBullet")]
public class MegaBullet : Ability
{
    public GameObject BulletPrefab;
   
    public override void Activate(GameObject player)
    {
        // Calculate the direction from the player to the mouse position
        Vector3 direction = (GetMouseWorldPosition() - player.transform.position).normalized;

        // Calculate the offset direction by rotating the direction vector
        Quaternion rotation = Quaternion.AngleAxis(0f, Vector3.forward);
        Vector3 offsetDirection = rotation * direction;

        // Calculate the position to instantiate the bullet, offset from the player
        Vector3 spawnPosition = player.transform.position + offsetDirection * 0.25f;

        // Instantiate the bullet prefab at the calculated position and rotation
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
