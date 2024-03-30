using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/Teleport")]  //loh bi nardila se nek tranzition fade in/out
public class Teleport : Ability {
    public int distance;
    public GameObject shadow;
    public override void Activate(GameObject player)
    {
        ShadowSpawn(player.transform.position);


        Vector3 currentPlayerPos = player.transform.position;
        float visina = currentPlayerPos.z;
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        Vector3 direction = mousePos - currentPlayerPos;
        direction.z = visina; //ohranimo visino

        Vector3 teleportPos = currentPlayerPos + direction.normalized * distance;

        player.transform.position = teleportPos;
    }
    private void ShadowSpawn(Vector3 pos)
    {
        GameObject shadowInstance = Instantiate(shadow, pos, Quaternion.identity);
 
    }
}

