using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Stats : MonoBehaviour
{


    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    public int maxXp;
    [HideInInspector]public int currentXp = 0;
    [HideInInspector]public int lvl = 1;


    public int damage;
    public float bulletSpeed;
    public int speed;
    public float attackSpeed;
    public int BodyDamage;
    public float knockbackForce;


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
            GameObject sceneLoader = GameObject.FindWithTag("SceneLoader");
            LevelLoader skripta = sceneLoader.GetComponent<LevelLoader>();
            skripta.LoadNextLevel();
            //DEJ TLE SE DA ZAMENJA SKIN NA CIS TAZADNGA V LISTU, K JE PA KAO K SI MRTU
        }
        

        //fake metode
        if (Input.GetKeyDown(KeyCode.Space)) {
            TakeDamage(10);
            GetXp(50);
        }

        if (currentXp >= maxXp)
        {
            currentXp -= maxXp;
            lvl++;
            maxXp += (int)maxXp / 2;
            xpBar.SetMaxXP(maxXp);
            xpBar.SetXP(currentXp);
            xpBar.LevelDisplay(lvl);
            GetComponent<SkinChanger>().ChangeSkin(lvl - 1); //pol k jih bo veè si player zbere kerega
            //GetComponent<AbilitySelect>().SelectAbility(lvl);
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
    //KNOCK BACK
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {

            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();

            Vector3 knockbackDirection = collision.gameObject.transform.position - transform.position;
            knockbackDirection.Normalize();

            enemyRigidbody.AddForce(knockbackDirection * knockbackForce, ForceMode.Impulse);

        }
    }

}
