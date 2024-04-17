using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class HUDManager : MonoBehaviour
{
    public Image power;
    public Image utility;
    public Image adaptive;
    public Image bullet;

    public TMP_Text powerT;
    public TMP_Text utilityT;
    public TMP_Text adaptiveT;

    public int powerLvl = 0;
    public int utilityLvl = 0;
    public int adaptiveLvl = 0;



    GameObject eventHandler;
    EventHadler eventScript;

    void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("EventHandler");
        eventScript = eventHandler.GetComponent<EventHadler>();

        power.sprite = eventScript.PowerSprites[powerLvl];
        power.color = new Color(power.color.r, power.color.g, power.color.b, 0.7f);

        utility.sprite = eventScript.UtilitySprites[utilityLvl];
        utility.color = new Color(utility.color.r, utility.color.g, utility.color.b, 0.7f);

        adaptive.sprite = eventScript.AdaptiveSprites[adaptiveLvl];
        adaptive.color = new Color(adaptive.color.r, adaptive.color.g, adaptive.color.b, 0.7f);
    }

    public void updatePower()
    {
        power.sprite = eventScript.PowerSprites[powerLvl];
        powerLvl++;
        power.color = new Color(power.color.r, power.color.g, power.color.b, 1f);
        powerT.text = $"{powerLvl}";
    }
    public void updateUtility()
    {
        utility.sprite = eventScript.UtilitySprites[utilityLvl];
        utilityLvl++;
        utility.color = new Color(utility.color.r, utility.color.g, utility.color.b, 1f);
        utilityT.text = $"{utilityLvl}";
    }
    public void updateAdaptive()
    {
        adaptive.sprite = eventScript.AdaptiveSprites[adaptiveLvl];
        adaptiveLvl++;
        adaptive.color = new Color(adaptive.color.r, adaptive.color.g, adaptive.color.b, 1f);
        adaptiveT.text = $"{adaptiveLvl}";
    }





}
