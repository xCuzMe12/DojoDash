using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class TextUpdater : MonoBehaviour
{
    public GameObject info;
    private TMP_Text infoText;

    public GameObject speed;
    public GameObject attackSpeed;
    public GameObject health;
    public GameObject damage;
    public GameObject pen;
    public GameObject bodyDamage;
    public GameObject bulletSpeed;
    public GameObject heal;
    //public Text speed;

    private TMP_Text speedText;
    private TMP_Text attackSpeedText;
    private TMP_Text healthText;
    private TMP_Text damageText;
    private TMP_Text penText;
    private TMP_Text bodyDamageText;
    private TMP_Text bulletSpeedText;
    private TMP_Text healText;

    void Start()
    {
        infoText = info.GetComponent<TMP_Text>();
        setInfo();

        speedText = speed.GetComponent<TMP_Text>();
        attackSpeedText = attackSpeed.GetComponent<TMP_Text>();
        healthText = health.GetComponent<TMP_Text>();
        damageText = damage.GetComponent<TMP_Text>();
        penText = pen.GetComponent<TMP_Text>();
        bodyDamageText = bodyDamage.GetComponent<TMP_Text>();
        bulletSpeedText = bulletSpeed.GetComponent<TMP_Text>();
        healText = heal.GetComponent<TMP_Text>();
    }

    public void SetText(string index, int upgLvl, int lvlCap)
    {
        switch (index)
        {
            case "speed":
                speedText.text = $"SPEED ({upgLvl}/{lvlCap})";
                    break;
            case "attackSpeed":
                attackSpeedText.text = $"ATTACK SPEED ({upgLvl}/{lvlCap})";
                break;
            case "health":
                healthText.text = $"MAX HEALTH ({upgLvl}/{lvlCap})";
                break;
            case "damage":
                damageText.text = $"DAMAGE ({upgLvl}/{lvlCap})";
                break;
            case "pen":
                penText.text = $"PENETRATION ({upgLvl}/{lvlCap})";
                break;
            case "bodyDamage":
                bodyDamageText.text = $"BODY DAMAGE ({upgLvl}/{lvlCap})";
                break;
            case "bulletSpeed":
                bulletSpeedText.text = $"BULLET SPEED ({upgLvl}/{lvlCap})";
                break;
            case "heal":
                healText.text = $"HEAL +{upgLvl} (COST: {lvlCap})"; //tuki svamal cheatala system, mal drugace
                    break;
        }
    }

    public void setInfo()
    {
        infoText.text = $"UPGRADES:" + "\n" +
                        "I -- 25$" + "\n" +
                        "II -- 35$" + "\n" +
                        "III -- 50$" + "\n" +
                        "IV -- 75$" + "\n" +
                        "V -- 100$";
    }

}
