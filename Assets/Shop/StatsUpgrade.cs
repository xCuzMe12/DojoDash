using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class StatsUpgrade : MonoBehaviour
{
    public int speedI = 0; //INDEXI
    public int healthI = 0;
    public int attackSpeedI = 0;
    public int bodyDMGI = 0;
    public int DMGI = 0;
    public int bulletSpeedI = 0;
    public int bulletPenI = 0;
    public StatsScheme shema;
    GameObject player;
    Stats stats;
    TextUpdater textUpdater;
    //restrictions
    int lvlCap = 5;
    int numOfUpg = 0;

    //heal potion
    public int numOfHeals = 0;
    public int healPrice = 25;
    public int addup = 5;
    public int healUp = 20;



    public void Start()
    {
        textUpdater = GetComponent<TextUpdater>();
        shema = GetComponent<StatsScheme>();
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<Stats>();
        //attackspeed
        Transform rotatePointT = player.transform.Find("RotatePoint");
        GameObject rotatePoint = rotatePointT.gameObject;
        Shooting shooting = rotatePoint.GetComponent<Shooting>();
    }

   public void speedUpg()
    {    
       if (numOfUpg < stats.lvl)
        {
            if (speedI < lvlCap && shema.cost[speedI + 1] <= stats.gold)
            {
                speedI++;
                stats.speed = shema.speed[speedI];
                stats.gold -= shema.cost[speedI];
                player.GetComponent<playerMovement>().UpdateSpeed();
                numOfUpg++;
                textUpdater.SetText("speed", speedI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
       else { Debug.Log("To small lvl"); }

    }

    public void healthUpg()
    {
        if (numOfUpg < stats.lvl)
        {
            if (healthI < lvlCap && shema.cost[healthI + 1] <= stats.gold)
            {
                healthI++;
                int addup = shema.maxHp[healthI] - stats.maxHealth; //zracunas razliko
                stats.maxHealth = shema.maxHp[healthI];
                stats.currentHealth += addup;
                stats.gold -= shema.cost[healthI];
                stats.healthBar.SetMaxHealth(stats.maxHealth);
                stats.healthBar.SetHealth(stats.currentHealth);
                stats.healthBar.HealthDisplay();
                numOfUpg++;
                textUpdater.SetText("health", healthI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
        else { Debug.Log("To small lvl"); }


    }
    public void attackSpeedUpg()
    {
        if (numOfUpg < stats.lvl)
        {
            if (attackSpeedI < lvlCap && shema.cost[attackSpeedI + 1] <= stats.gold)
            {
                attackSpeedI++;
                stats.attackSpeed = shema.attackSpeed[attackSpeedI];
                stats.gold -= shema.cost[attackSpeedI];
                numOfUpg++;
                textUpdater.SetText("attackSpeed", attackSpeedI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
        else { Debug.Log("To small lvl"); }


    }
    public void bodyDMGUpg()
    {
        if (numOfUpg < stats.lvl)
        {
            if (bodyDMGI < lvlCap && shema.cost[bodyDMGI + 1] <= stats.gold)
            {
                bodyDMGI++;
                stats.BodyDamage = shema.bodyDmg[bodyDMGI];
                stats.gold -= shema.cost[bodyDMGI];
                numOfUpg++;
                textUpdater.SetText("bodyDamage", bodyDMGI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
        else { Debug.Log("To small lvl"); }



    }
    public void DMGUpg()
    {
        if (numOfUpg < stats.lvl)
        {
            if (DMGI < lvlCap && shema.cost[DMGI + 1] <= stats.gold)
            {
                DMGI++;
                stats.damage = shema.dmg[DMGI];
                stats.gold -= shema.cost[DMGI];
                numOfUpg++;
                textUpdater.SetText("damage", DMGI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
        else { Debug.Log("To small lvl"); }




    }
    public void bulletSpeedUpg()
    { 
        if (numOfUpg < stats.lvl)
        {
            if (bulletSpeedI < lvlCap && shema.cost[bulletSpeedI + 1] <= stats.gold)
            {
                bulletSpeedI++;
                stats.bulletSpeed = shema.bulletSpeed[bulletSpeedI];
                stats.gold -= shema.cost[bulletSpeedI];
                numOfUpg++;
                textUpdater.SetText("bulletSpeed", bulletSpeedI, lvlCap);
                stats.statsDisplay.Display();
            }
            else
            {
                Debug.Log("Yu broke");
            }
        }
        else { Debug.Log("To small lvl"); }



    }
    public void bulletPenUpg() //DODEJ KO BOS
    {
        bulletPenI++;
    }

    public void HealUp()
    {
        int cost = healPrice + addup * numOfHeals;
        if (cost <= stats.gold)
        {
            stats.currentHealth += healUp;
            stats.gold -= cost;
            stats.healthBar.SetHealth(stats.currentHealth);
            stats.healthBar.HealthDisplay();
            textUpdater.SetText("heal", healUp, cost);
            stats.statsDisplay.Display();
            numOfHeals++;
        }
    }
}
