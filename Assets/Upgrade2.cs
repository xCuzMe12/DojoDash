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
        Debug.Log("21");
        puscica.GetComponent<Shooting>().upgtype += "21";
    }

    public void DvaNazajVzp() //22
    {
        Debug.Log("22");

        puscica.GetComponent<Shooting>().upgtype += "22";
    }

    public void DvaOkoli() //23
    {
        Debug.Log("23");

        puscica.GetComponent<Shooting>().upgtype += "23";
    }
    public void StiriVVse() //24
    {
        Debug.Log("24");

        puscica.GetComponent<Shooting>().upgtype += "24";
    }

}
