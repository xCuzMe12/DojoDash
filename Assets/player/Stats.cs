using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stats : MonoBehaviour
{


    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    public int maxXp;
    private int currentXp = 0;
    private int lvl = 1;


    public int damage;
    public float bulletSpeed;
    public int speed;
    public float attackSpeed;


    public int maxDamage = 50;
    public int maxSpeed = 20;
    public float maxAttackSpeed = 20;

    //healthbar
    public HealthBar healthBar;
    public XPBar xpBar;

    [HideInInspector] public int kills = 0;

    //tobos uporabu k bos upgradu statse mors se to updatat
    public StatsDisplay statsDisplay;



    void Start()
    {
        currentHealth = maxHealth;
        
        healthBar.SetMaxHealth(maxHealth);
        healthBar.HealthDisplay();
        xpBar.SetMaxXP(maxXp);
        xpBar.SetXP(currentXp);
        xpBar.LevelDisplay(lvl);
        statsDisplay.Display();

    }

    
    void Update()
    {
        if (currentHealth > maxHealth)
        {
            currentHealth = Mathf.Clamp(currentHealth, 0, maxHealth);
        }
        if (currentHealth <= 0) { 
            Destroy(gameObject);
            Debug.Log("You died");
            //TLE DAS SCENE MANAGER ZA SMRT, MAGAR TO PO KOLOKVIJU
        }
        

        //fake metode
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
            GetXp(8);
        }

        if (currentXp >= maxXp)
        {
            currentXp -= maxXp;
            lvl++;
            maxXp += (int)maxXp / 2;
            xpBar.SetMaxXP(maxXp);
            xpBar.SetXP(currentXp);
            xpBar.LevelDisplay(lvl);
        }

        




    }


    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
        healthBar.HealthDisplay();

    }
    public void GetXp(int xp)
    {
        currentXp += xp;
        


        if (currentXp >= maxXp)
        {
            return;
        }
        else
        {
            xpBar.SetXP(currentXp);
            xpBar.LevelDisplay(lvl);
        }

    }


}
