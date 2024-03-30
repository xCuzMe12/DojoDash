using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Abilities/CrossbowTurret")]
public class CrossbowTurret : Ability
{
    public GameObject TurretPrefab;

    public override void Activate(GameObject player)
    {
        Instantiate(TurretPrefab, player.transform.position, player.transform.rotation);
    }
}
