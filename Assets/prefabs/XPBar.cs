using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class XPBar : MonoBehaviour
{
    public Slider slider;
    public Text levelText;

    public void SetXP(int xp)
    {
        slider.value = xp;
    }

    public void SetMaxXP(int xp)
    {
        slider.maxValue = xp;
        slider.value = xp;
    }

    //ta je ful zanimiva - sam das en text component notr, sam poz zrihtas, ostalo loh tukej
    public void LevelDisplay(int level)
    {
        levelText.text = "LVL: " + level.ToString() + " " + slider.value.ToString() + "/" + slider.maxValue.ToString();
    }

}
