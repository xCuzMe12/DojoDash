using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovement : MonoBehaviour
{
    public float enemySpeed;
    Rigidbody2D rb;
    public GameObject player;
    public int health;

    //public GameObject healthText; //to nared se

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        
        Vector2 direction = (player.transform.position - transform.position).normalized;
        rb.velocity = direction * enemySpeed;
    }
}
