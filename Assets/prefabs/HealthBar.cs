using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Text healthText;

    public void SetHealth(int health)
    {
        slider.value = health;
    }

    public void SetMaxHealth(int health)
    {
        slider.maxValue = health;
        slider.value = health;
    }

    public void HealthDisplay()
    {
        healthText.text = slider.value.ToString() + "/" + slider.maxValue.ToString();
        //ta .text je pa da dejansko text property od komponente Text
    }
}
