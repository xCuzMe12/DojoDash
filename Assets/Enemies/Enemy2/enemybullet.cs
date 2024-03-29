using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class enemybullet : MonoBehaviour
{
    private GameObject enemy2;
    enemyStats2 statsEnemy;

    GameObject target;
    private Rigidbody2D rb;

    void Start()
    {
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        statsEnemy = enemy2.GetComponent<enemyStats2>();



        target = GameObject.FindGameObjectWithTag("Player");
        Vector3 dir = target.transform.position - transform.position;
        Vector3 rotation = transform.position - target.transform.position;
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);

        rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2 (dir.x, dir.y).normalized * statsEnemy.bulletSpeed;
        StartCoroutine(Destruction());
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Stats stats = collision.gameObject.GetComponent<Stats>();
            stats.TakeDamage(statsEnemy.dmg);
            Destroy(gameObject);
        }
        else { Destroy(gameObject); }
    }


    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(statsEnemy.lifetime); 
        Destroy(gameObject);
    }
}
