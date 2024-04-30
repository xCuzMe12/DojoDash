using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Bomb")]
public class Bomb : Ability
{
    public GameObject bomb;
    [HideInInspector] public Vector3 BombPos;
    public override void Activate(GameObject player)
    {       

        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f; // Ensure the z-coordinate is 0 (on the ground)

        // Calculate the direction from the player to the mouse position
        Vector3 direction = mousePosition - player.transform.position;
        direction.Normalize(); // Normalize the direction vector

        // Calculate the spawn position a few units ahead of the player
        Vector3 spawnPosition = player.transform.position + direction * 2f;

        // Instantiate the turret at the calculated spawn position

        Instantiate(bomb, spawnPosition, Quaternion.identity, player.transform);
        //Detonate dt = bomb.GetComponent<Detonate>();
        //dt.pl = player;

    }
    
}
