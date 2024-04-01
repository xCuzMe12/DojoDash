using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatsDisplay : MonoBehaviour
{
    public Text statsText;

    public GameObject player;
    

    private void Awake()
    {
        Stats stats = player.GetComponent<Stats>();
        
    }

    public void Display()
    {
        string stats =
         "GOLD: " + player.GetComponent<Stats>().gold.ToString() + "\n" +
         "KILLS: " + player.GetComponent<Stats>().kills;


        statsText.text = stats;
    }


}
