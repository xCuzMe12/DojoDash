using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilityUpg : MonoBehaviour
{

    public ScriptableObject[] abilityPower;
    public ScriptableObject[] abilityUtility;
    public ScriptableObject[] abilityAdaptive;

    int powerLvl = 0;
    int utilityLvl = 0;
    int adaptiveLvl = 0;



    public GameObject PowerIMG;
    public GameObject UtilityIMG;
    public GameObject AdaptiveIMG;


    public GameObject player;
    AbilityHolder abilityHolder;

    GameObject eventHandler;
    EventHadler eventScript;
    void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("EventHandler");
        eventScript = eventHandler.GetComponent<EventHadler>();
        abilityPower = eventScript.abilityPower;
        //abilityUtility = eventScript.abilityUtility; - ko dodas
        //abilityAdaptive = eventScript.abilityAdaptive;

        abilityHolder = player.GetComponent<AbilityHolder>();
    }


    public void PowerAbilityUpg()
    {
        if (powerLvl < 3)
        {
            abilityHolder.ability = (Ability)abilityPower[powerLvl];
            powerLvl++;
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
