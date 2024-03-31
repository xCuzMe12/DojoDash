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
    int lvlCap = 5;

    public void Start()
    {
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
        if (speedI < lvlCap && shema.cost[speedI+1] <= stats.gold)
        {
            speedI++;
            stats.speed = shema.speed[speedI];
            stats.gold -= shema.cost[speedI];
            player.GetComponent<playerMovement>().UpdateSpeed();
        }
        else
        {
            Debug.Log("Yu broke");
        }
    }

    public void healthUpg()
    {
        if (healthI < lvlCap && shema.cost[healthI + 1] <= stats.gold)
        {
            healthI++;
            int addup = shema.maxHp[healthI] - stats.maxHealth; //zracunas razliko
            stats.maxHealth = shema.maxHp[healthI];
            stats.currentHealth += addup;
            stats.gold -= shema.cost[healthI];
            stats.healthBar.SetMaxHealth(stats.maxHealth);
            stats.healthBar.HealthDisplay();
        }
        else
        {
            Debug.Log("Yu broke");
        }

    }
    public void attackSpeedUpg()
    {
        if (attackSpeedI < lvlCap && shema.cost[attackSpeedI + 1] <= stats.gold)
        {
            attackSpeedI++;
            stats.attackSpeed = shema.attackSpeed[attackSpeedI];
            stats.gold -= shema.cost[attackSpeedI];
        }
        else
        {
            Debug.Log("Yu broke");
        }

    }
    public void bodyDMGUpg()
    {
        if (bodyDMGI < lvlCap && shema.cost[bodyDMGI + 1] <= stats.gold)
        {
            bodyDMGI++;
            stats.BodyDamage = shema.bodyDmg[bodyDMGI];
            stats.gold -= shema.cost[bodyDMGI];
        }
        else
        {
            Debug.Log("Yu broke");
        }


    }
    public void DMGUpg()
    {
        if (DMGI < lvlCap && shema.cost[DMGI + 1] <= stats.gold)
        {
            DMGI++;
            stats.damage = shema.dmg[DMGI];
            stats.gold -= shema.cost[DMGI];
        }
        else
        {
            Debug.Log("Yu broke");
        }



    }
    public void bulletSpeedUpg()
    {
        if (bulletSpeedI < lvlCap && shema.cost[bulletSpeedI + 1] <= stats.gold)
        {
            bulletSpeedI++;
            stats.bulletSpeed = shema.bulletSpeed[bulletSpeedI];
            stats.gold -= shema.cost[bulletSpeedI];

        }
        else
        {
            Debug.Log("Yu broke");
        }


    }
    public void bulletPenUpg() //DODEJ KO BOS
    {
        bulletPenI++;
    }
}
