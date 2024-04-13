using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextUpdaterAbilities : MonoBehaviour
{

    public GameObject powerAbility;
    public GameObject utilityAbility;
    public GameObject adaptiveAbility;

    TMP_Text powerAbilityText;
    TMP_Text utilityAbilityText;
    TMP_Text adaptiveAbilityText;




    void Start()
    {
        powerAbilityText = powerAbility.GetComponent<TMP_Text>();
        utilityAbilityText = utilityAbility.GetComponent<TMP_Text>();
        adaptiveAbilityText = adaptiveAbility.GetComponent<TMP_Text>();
    }
    public void SetText(string index, int upgLvl, int lvlCap, int price)
    {
        switch (index)
        {
            case "power":
                powerAbilityText.text = $" ({upgLvl}/{lvlCap}) \n {price}$";
                break;
            case "utility":
                utilityAbilityText.text = $" ({upgLvl}/{lvlCap}) \n {price}$";
                break;
            case "adaptive":
                adaptiveAbilityText.text = $" ({upgLvl}/{lvlCap}) \n  {price} $";
                break;
            case "powerMAX":
                powerAbilityText.text = "MAXED OUT";
                break;
            case "utilityMAX":
                utilityAbilityText.text = "MAXED OUT";
                break;
            case "adaptiveMAX":
                adaptiveAbilityText.text = "MAXED OUT";
                break;
        }
    }

}
