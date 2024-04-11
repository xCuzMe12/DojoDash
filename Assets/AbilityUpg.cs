using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AbilityUpg : MonoBehaviour
{

    public ScriptableObject[] abilityPower;
    public ScriptableObject[] abilityUtility;
    public ScriptableObject[] abilityAdaptive;

    int powerLvl = 0;
    int utilityLvl = 0;
    int adaptiveLvl = 0;


    //images
    public GameObject PowerIMG;
    public GameObject UtilityIMG;
    public GameObject AdaptiveIMG;

    public Sprite[] PowerSprites;
    public Sprite[] UtilitySprites;
    public Sprite[] AdaptiveSprites;

    public int[] PowerPrice;
    public int[] UtilityPrice;
    public int[] AdaptivePrice;

    TextUpdaterAbilities abilityUpgText;


    public GameObject player;
    Stats stats;
    AbilityHolder abilityHolder;

    GameObject eventHandler;
    EventHadler eventScript;
    void Start()
    {

        eventHandler = GameObject.FindGameObjectWithTag("EventHandler");
        eventScript = eventHandler.GetComponent<EventHadler>();
        abilityPower = eventScript.abilityPower;
        PowerSprites = eventScript.PowerSprites; 
        PowerPrice = eventScript.PowerPrice;


        //UtilityPrice = eventScript.UtilityPrice;
        //AdaptivePrice = eventScript.AdaptivePrice;
        //UtilitySprites = eventScript.UtilitySprites; 
        //AdaptiveSprites = eventScript.AdaptiveSprites;
        //abilityUtility = eventScript.abilityUtility; - ko dodas
        //abilityAdaptive = eventScript.abilityAdaptive;

        PowerIMG.GetComponent<Image>().sprite = PowerSprites[0];
        //UtilityIMG.GetComponent<Image>().sprite = UtilitySprites[0];
        //AdaptiveIMG.GetComponent<Image>().sprite = AdaptiveSprites[0];


        abilityHolder = player.GetComponent<AbilityHolder>();
        stats = player.GetComponent<Stats>();

        abilityUpgText = GetComponent<TextUpdaterAbilities>();
        abilityUpgText.SetText("power", 0, 3, PowerPrice[0]);
        abilityUpgText.SetText("utility", 0, 3, 0);//UtilityPrice[0]
        abilityUpgText.SetText("adaptive", 0, 3, 0);//AdaptivePrice[0] -- to zamenji k mas
    }


    public void PowerAbilityUpg()
    {
        if (powerLvl < 3 && PowerPrice[powerLvl] <= stats.gold)
        {
            stats.gold -= PowerPrice[powerLvl];
            abilityHolder.ability = (Ability)abilityPower[powerLvl];
            PowerIMG.GetComponent<Image>().sprite = PowerSprites[powerLvl];
            powerLvl++;

            if (powerLvl == 3)
            {
                abilityUpgText.SetText("powerMAX", 0, 0, 0);

            }
            else
            {
                abilityUpgText.SetText("power", powerLvl, 3, PowerPrice[powerLvl]);
            }
            stats.statsDisplay.Display();
        }
    }

    public void UtilityAbilityUpg()
    {

    }
    public void AdaptiveAbilityUpg()
    {

    }


    void Update()
    {
        
    }
}
