using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUpg : MonoBehaviour
{
    public GameObject shuriken;
    public GameObject dagger;
    public GameObject kunai;

    public GameObject shurObj;
    public GameObject daggObj;
    public GameObject kunObj;

    TextUpdaterWeapons upgText;


    GameObject bullet;
    GameObject player;
    Stats stats;
    GameObject rotatePoint;
    Shooting shooting;


    int lvlCap = 3;
    int currLvl = 0;
    int[] cene = { 0, 100, 200, 350 };


    void Start()
    {
        upgText = GetComponent<TextUpdaterWeapons>();
        player = GameObject.FindGameObjectWithTag("Player");
        Transform rotatePointT = player.transform.Find("RotatePoint");
        rotatePoint = rotatePointT.gameObject;
        shooting = rotatePoint.GetComponent<Shooting>();
        stats = player.GetComponent<Stats>();
    }

    public void KunaiUpg()
    {
        if (currLvl < lvlCap && cene[currLvl + 1] <= stats.gold)
        {
            currLvl++;
            stats.gold -= cene[currLvl];
            stats.statsDisplay.Display();
            upgText.SetText("wpn3", currLvl, lvlCap);
            if (currLvl == 1)
            {
                shooting.bullet = kunai;
                kunObj.transform.position = new Vector3(195, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(shurObj);
                Destroy(daggObj);
            }
            else
            {

            }
        }



    }
    public void ShurikenUpg()
    {
        if (currLvl < lvlCap && cene[currLvl + 1] <= stats.gold)
        {
            currLvl++;
            stats.gold -= cene[currLvl];
            stats.statsDisplay.Display();
            upgText.SetText("wpn1", currLvl, lvlCap);
            if (currLvl == 1)
            {
                shooting.bullet = shuriken;
                shurObj.transform.position = new Vector3(640f, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(daggObj);
                Destroy(kunObj);
            }
            else
            {

            }
        }
    }

    public void DaggerUpg()
    {
        if (currLvl < lvlCap && cene[currLvl + 1] <= stats.gold)
        {
            currLvl++;
            stats.gold -= cene[currLvl];
            stats.statsDisplay.Display();
            upgText.SetText("wpn2", currLvl, lvlCap);
            if (currLvl == 1)
            {
                shooting.bullet = dagger;
                daggObj.transform.position = new Vector3(420f, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(kunObj);
                Destroy(shurObj);
            }
            else
            {

            }
        }
    }


}
