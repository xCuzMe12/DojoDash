using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Teleport")]
public class Teleport : Ability {
    public int distance;
    public override void Activate(GameObject player)
    {
        
        Vector3 currentPlayerPos = player.transform.position;
        float visina = currentPlayerPos.z;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - currentPlayerPos;
        direction.z = visina; //ohranimo visino

        Vector3 teleportPos = currentPlayerPos + direction.normalized * distance;

        player.transform.position = teleportPos;
    }
}

