using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//to je sam template - vsi powerupi iz tega, tko k abstract parent
public abstract class PowerupEffect : ScriptableObject
{
    public abstract void Apply(GameObject target);

}
