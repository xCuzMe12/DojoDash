using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(menuName = "Abilities/GrapplingHook")]
public class GraplingHook : Ability
{
    public GameObject hook;

    public override void Activate(GameObject player)
    {
        Instantiate(hook, player.transform.position, Quaternion.identity, player.transform);
    }
}
