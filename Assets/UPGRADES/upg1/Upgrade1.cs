using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade1 : MonoBehaviour
{
    Shooting shootingScript;
    GameObject puscica;
    private void Start()
    {
        puscica = GameObject.FindGameObjectWithTag("ShootingPrefab");
    }

    public void DvaVzporedno() //11
    {
        puscica.GetComponent<Shooting>().upgtype = "11";
    }

    public void TriNaprej() //12
    {
        puscica.GetComponent<Shooting>().upgtype = "12";
    }

    public void DvaZaporedno() //13
    {
        puscica.GetComponent<Shooting>().upgtype = "13";
    }
    public void DvaNazaj() //14
    {
        puscica.GetComponent<Shooting>().upgtype = "14";
    }

}
