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
    AbilityHolderADAPTIVE abilityHolderAdaptive;
    AbilityHolderUtility abilityHolderUtility;


    GameObject eventHandler;
    EventHadler eventScript;
    void Start()
    {

        eventHandler = GameObject.FindGameObjectWithTag("EventHandler");
        eventScript = eventHandler.GetComponent<EventHadler>();

        abilityPower = eventScript.abilityPower;
        PowerSprites = eventScript.PowerSprites; 
        PowerPrice = eventScript.PowerPrice;

        abilityAdaptive = eventScript.abilityAdaptive;
        AdaptiveSprites = eventScript.AdaptiveSprites;
        AdaptivePrice = eventScript.AdaptivePrice;

        UtilityPrice = eventScript.UtilityPrice;
        UtilitySprites = eventScript.UtilitySprites; 
        abilityUtility = eventScript.abilityUtility; 

        PowerIMG.GetComponent<Image>().sprite = PowerSprites[0];
        AdaptiveIMG.GetComponent<Image>().sprite = AdaptiveSprites[0];
        UtilityIMG.GetComponent<Image>().sprite = UtilitySprites[0];


        abilityHolder = player.GetComponent<AbilityHolder>();
        abilityHolderAdaptive = player.GetComponent<AbilityHolderADAPTIVE>();
        abilityHolderUtility = player.GetComponent<AbilityHolderUtility>();
        stats = player.GetComponent<Stats>();

        abilityUpgText = GetComponent<TextUpdaterAbilities>();
        abilityUpgText.SetText("power", 0, 3, PowerPrice[0]);
        abilityUpgText.SetText("utility", 0, 3, UtilityPrice[0]);
        abilityUpgText.SetText("adaptive", 0, 3, AdaptivePrice[0]); 
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
        if (utilityLvl < 3 && UtilityPrice[utilityLvl] <= stats.gold)
        {
            stats.gold -= UtilityPrice[utilityLvl];
            abilityHolderUtility.ability = (Ability)abilityUtility[utilityLvl];
            UtilityIMG.GetComponent<Image>().sprite = UtilitySprites[utilityLvl];
            utilityLvl++;

            if (utilityLvl == 3)
            {
                abilityUpgText.SetText("utilityMAX", 0, 0, 0);

            }
            else
            {
                abilityUpgText.SetText("utility", utilityLvl, 3, UtilityPrice[utilityLvl]);
            }
            stats.statsDisplay.Display();
        }
    }
    public void AdaptiveAbilityUpg()
    {
        if (adaptiveLvl < 3 && AdaptivePrice[adaptiveLvl] <= stats.gold)
        {
            stats.gold -= AdaptivePrice[adaptiveLvl];
            abilityHolderAdaptive.ability = (Ability)abilityAdaptive[adaptiveLvl];
            AdaptiveIMG.GetComponent<Image>().sprite = AdaptiveSprites[adaptiveLvl];
            adaptiveLvl++;

            if (adaptiveLvl == 3)
            {
                abilityUpgText.SetText("adaptiveMAX", 0, 0, 0);

            }
            else
            {
                abilityUpgText.SetText("adaptive", adaptiveLvl, 3, AdaptivePrice[adaptiveLvl]);
            }
            stats.statsDisplay.Display();
        }
    }


    void Update()
    {
        
    }
}
