using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WeaponsUpg : MonoBehaviour
{

    public GameObject[] KunaiArray;
    public GameObject[] ShurikenArray;
    public GameObject[] DaggerArray;

    public Sprite[] DaggerRenderers;
    public Sprite[] KunaiRenderers;
    public Sprite[] ShurikenRenderers;

    public GameObject KunaiIMG;
    public GameObject DaggerIMG;
    public GameObject ShurikenIMG;



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

        upgText.setInfoWeapons();
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
                shooting.bullet = KunaiArray[0];
                kunObj.transform.position = new Vector3(195, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(shurObj);
                Destroy(daggObj);
            }
            else
            {
                shooting.bullet = KunaiArray[currLvl - 1]; //upg skin pa nou prefab das za metk
                KunaiIMG.GetComponent<Image>().sprite = KunaiRenderers[currLvl - 2];
            }
            stats.damage += KunaiArray[currLvl - 1].GetComponent<bullet>().damageChange;
            stats.attackSpeed -= KunaiArray[currLvl - 1].GetComponent<bullet>().ASpeedChange;
        }



    }
    //TEDVE CIS ISTO UPDATAJ
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
                shooting.bullet = ShurikenArray[0];
                shurObj.transform.position = new Vector3(640f, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(daggObj);
                Destroy(kunObj);
            }
            else
            {
                shooting.bullet = ShurikenArray[currLvl - 1];
                ShurikenIMG.GetComponent<Image>().sprite = ShurikenRenderers[currLvl - 2];
            }
            stats.damage += ShurikenArray[currLvl - 1].GetComponent<bullet>().damageChange;
            stats.attackSpeed -= ShurikenArray[currLvl - 1].GetComponent<bullet>().ASpeedChange;
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
                shooting.bullet = DaggerArray[0];
                daggObj.transform.position = new Vector3(420f, shurObj.transform.position.y, shurObj.transform.position.z);
                Destroy(kunObj);
                Destroy(shurObj);
            }
            else
            {
                shooting.bullet = DaggerArray[currLvl - 1];
                DaggerIMG.GetComponent<Image>().sprite = DaggerRenderers[currLvl - 2];
            }
            stats.damage += DaggerArray[currLvl - 1].GetComponent<bullet>().damageChange;
            stats.attackSpeed -= DaggerArray[currLvl - 1].GetComponent<bullet>().ASpeedChange;
        }
    }


}
