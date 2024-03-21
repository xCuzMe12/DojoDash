using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Healthbuff")]
public class HealthBuff : PowerupEffect
{
    public int amount;

    public override void Apply(GameObject target)
    {

        target.GetComponent<Stats>().currentHealth += amount;
        //updatas fill
        target.GetComponent<Stats>().healthBar.SetHealth(target.GetComponent<Stats>().currentHealth);
        target.GetComponent<Stats>().healthBar.HealthDisplay();
    }

}
