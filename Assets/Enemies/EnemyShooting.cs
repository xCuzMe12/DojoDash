using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Misc;
using UnityEngine;

public class EnemyShooting : MonoBehaviour
{
    public bool CanFire;
    private float timer;

    private GameObject enemy2;
    enemyStats2 statsEnemy;

    public GameObject bullet;
    public Transform bulletTransform;
    private void Start()
    {
        enemy2 = GameObject.FindGameObjectWithTag("Enemy2");
        statsEnemy = enemy2.GetComponent<enemyStats2>();
    }

    void Update()
    {
        if (CanFire)
        {
            CanFire = false;
            Instantiate(bullet, bulletTransform.position, Quaternion.identity);
        }
        else
        {
            timer += Time.deltaTime;
            if (statsEnemy != null && timer > statsEnemy.attackSpeed)
            {
                CanFire = true;
                timer = 0;
            }
        }
    }
}
