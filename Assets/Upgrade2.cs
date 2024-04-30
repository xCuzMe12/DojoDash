using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade2 : MonoBehaviour
{
    Shooting shootingScript;
    GameObject puscica;
    private void Start()
    {
        puscica = GameObject.FindGameObjectWithTag("ShootingPrefab");
    }

    public void VMisko() //21
    {
        puscica.GetComponent<Shooting>().upgtype += "21";
    }

    public void DvaNazajVzp() //22
    {

        puscica.GetComponent<Shooting>().upgtype += "22";
    }

    public void DvaOkoli() //23
    {

        puscica.GetComponent<Shooting>().upgtype += "23";
    }
    public void StiriVVse() //24
    {

        puscica.GetComponent<Shooting>().upgtype += "24";
    }

}
