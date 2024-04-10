using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdaterWeapons : MonoBehaviour
{



    public GameObject info;
    private TMP_Text infoText;

    public GameObject wpn1;
    public GameObject wpn2;
    public GameObject wpn3;

    private TMP_Text wpn1Text;
    private TMP_Text wpn2Text;
    private TMP_Text wpn3Text;

    void Start()
    {
        infoText = info.GetComponent<TMP_Text>();

        wpn1Text = wpn1.GetComponent<TMP_Text>();
        wpn2Text = wpn2.GetComponent<TMP_Text>();
        wpn3Text = wpn3.GetComponent<TMP_Text>();
    }

    public void SetText(string index, int upgLvl, int lvlCap)
    {
            switch (index)
            {
                case "wpn1":
                wpn1Text.text = $"SHURIKEN ({upgLvl}/{lvlCap})";
                    break;
                case "wpn2":
                wpn2Text.text = $"DAGGER ({upgLvl}/{lvlCap})";
                    break;
                case "wpn3":
                wpn3Text.text = $"KUNAI ({upgLvl}/{lvlCap})";
                    break;
            }
    }

    public void setInfoWeapons()
    {
        infoText.text = $"UPGRADES:" + "\n" +
                        "I -- 100$" + "\n" +
                        "II -- 200$" + "\n" +
                        "III -- 350$" + "\n";
    }

}


