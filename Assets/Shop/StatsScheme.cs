using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StatsScheme : MonoBehaviour
{
    //pri vseh prvi 0, da se nerabis z indexi jebat

    //COST VSEH 25 35 50 75 100 
    public int[] cost = {0, 25, 35, 50, 75, 100};
    //SPEED 5.6  6.4  7 8 9
    public float[] speed = { 0, 5.6f, 6.4f, 7f, 8f, 9f };


    public int[] maxHp = { 0, 60, 70, 85, 100, 120 };

    public int[] dmg = { 0, 2, 2, 3, 3, 3 };

    public int[] pen = { 0, 60, 70, 85, 100, 120 };

    public int[] bodyDmg = {0, 14, 18, 24, 30, 34};

    public int[] bulletSpeed = { 0, 14, 15, 16, 17, 19 };


    public float[] attackSpeed = { 0, 0.45f, 0.4f, 0.35f, 0.30f, 0.25f };



    

}
