using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Powerups/Speedbuff")]
public class SpeedBuff : PowerupEffect
{
    public int amount;
    public float duration = 5.0f;

    public override void Apply(GameObject target)
    {
        playerMovement movementScript = target.GetComponent<playerMovement>();
        movementScript.SpeedBoost(amount, duration);

    }

}   //TA JE CIST ZRIHTAN, NE VEC DIRAT
