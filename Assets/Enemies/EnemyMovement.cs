using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb;
    public GameObject player;
    public int enemyHealth = 15;
    public int enemyDMG = 5;

    //public GameObject healthText; 
    //za une mocnejse sam tle dodaji se fje za shooting pa to

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * enemySpeed;

        if (enemyHealth <= 0)
        {
            Destroy(gameObject);
        }

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats stats = collision.gameObject.GetComponent<Stats>();
            stats.TakeDamage(enemyDMG);
            enemyHealth -= stats.BodyDamage;
            

        }
    }
}
