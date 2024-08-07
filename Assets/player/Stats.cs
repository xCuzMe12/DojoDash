using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;

public class Stats : MonoBehaviour
{
    UpgradeManager upgradeManager;

    public int maxHealth;
    [HideInInspector]
    public int currentHealth;

    public int maxXp;
    [HideInInspector]public int currentXp = 0;
    [HideInInspector]public int lvl = 1;

    public int gold = 100;
    public int damage;
    public float bulletSpeed;
    public float speed;
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
        upgradeManager = GetComponent<UpgradeManager>();

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
            GetXp(50);
        }

        if (currentXp >= maxXp)
        {
            currentXp -= maxXp;
            lvl++;
            UpgradeScreen(lvl);
            maxXp += (int)maxXp / 2;
            maxXp = Mathf.Min(maxXp, 200 * (int)Mathf.Ceil(lvl / 5f)); //200 max je cisti max
            xpBar.SetMaxXP(maxXp);
            xpBar.SetXP(currentXp);
            xpBar.LevelDisplay(lvl);
            GetComponent<SkinChanger>().ChangeSkin(lvl - 1); //pol k jih bo ve� si player zbere kerega
            
        }








    }

    public void UpgradeScreen(int lvl)
    {
        if (lvl % 5 == 0)
        {
            int upgNum = lvl / 5;
            upgradeManager.OpenUpgradeScreen(upgNum);

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
