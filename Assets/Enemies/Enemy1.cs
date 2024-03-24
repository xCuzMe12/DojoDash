using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb;
    [HideInInspector]public GameObject player;
    public int enemyHealth = 15;
    public int enemyDMG = 5;
    public int enemyXP = 7;
    private WaitForSeconds updateDelay = new WaitForSeconds(1f); //fja kok sekund cakat

    //public GameObject healthText; 
    //za une mocnejse sam tle dodaji se fje za shooting pa to

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(UpdateMovementCoroutine());
    }

    IEnumerator UpdateMovementCoroutine()
    {
        while (true) //vsako eno sekundo zracuna kam more it
        {
            Vector2 direction = (player.transform.position - transform.position).normalized;
            rb.velocity = direction * enemySpeed;
            yield return updateDelay; 
        }
    }
    //basically vse interactione delas tle
    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(UpdateMovementCoroutine());
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats stats = collision.gameObject.GetComponent<Stats>();
            stats.TakeDamage(enemyDMG);
            enemyHealth -= stats.BodyDamage;
            if (enemyHealth <= 0)
            {
                OnDestroy(stats);

            }
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            bullet bullet = collision.gameObject.GetComponent<bullet>();
            enemyHealth -= bullet.damage;
            if (enemyHealth <= 0)
            {
                OnDestroy(bullet.stats);



            }
        }

        //vsakic k enemy umre klices to metodo
        void OnDestroy(Stats stats)
        {
            stats.kills++;
            stats.statsDisplay.Display();
            stats.currentXp += enemyXP;
            stats.xpBar.SetXP(stats.currentXp);
            stats.xpBar.LevelDisplay(stats.lvl);
            Destroy(gameObject);
 
        }
    }
}
