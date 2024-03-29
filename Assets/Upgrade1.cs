using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    public void DvaVzporedno()
    {
        GameObject rotatePoint = GameObject.FindGameObjectWithTag("ShootingPrefab");
        Shooting shooting = rotatePoint.GetComponent<Shooting>();  
        shooting.enabled = false;
        Shooting11 drugScript = rotatePoint.GetComponent<Shooting11>();
        drugScript.enabled = true;
    }
}
