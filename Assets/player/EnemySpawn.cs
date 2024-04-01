using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{

    public int SpawnTimer;
    public GameObject[] Enemies;
    public int RangeX;
    public int RangeY;
    public int SpawnProtectionRadius;

    private float CurrentTime;
    Transform playerT;
    GameObject player;
    HashSet<string> enemySet = new HashSet<string> { "Enemy", "Enemy2", "Enemy3", "Enemy4", "Enemy5", "Enemy6" };
    // Start is called before the first frame update
    void Start()
    {
        SpawnProtectionRadius = Mathf.Abs(SpawnProtectionRadius);
        RangeX = Mathf.Abs(RangeX);
        RangeY = Mathf.Abs(RangeY);
        playerT = transform.parent;
        player = playerT.gameObject;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= SpawnTimer)
        {
            CurrentTime = 0;

            int randomX;
            int randomY;
            do
            {
                randomX = Random.Range(RangeX * (-1), RangeX + 1);
            } while (Mathf.Abs(randomX) * (-1) >= SpawnProtectionRadius * (-1) && Mathf.Abs(randomX) <= SpawnProtectionRadius);

            do
            {
                randomY = Random.Range(RangeY * (-1), RangeY + 1);
            } while (Mathf.Abs(randomY) * (-1) >= SpawnProtectionRadius * (-1) && Mathf.Abs(randomY) <= SpawnProtectionRadius);

            GameObject enemy = Enemies[Random.Range(0, Enemies.Length)];


            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            spawnPosition.x += player.transform.position.x;
            spawnPosition.y += player.transform.position.y;
            if (!CheckForObjectAtPoint(spawnPosition, 2)){
                Instantiate(enemy, spawnPosition, Quaternion.identity);
            }         
        }
    }

    public bool CheckForObjectAtPoint(Vector3 pos, float radius)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, radius);

        foreach (Collider2D collider in colliders)
        {
            if (enemySet.Contains(collider.gameObject.tag) || collider.gameObject.tag == "border")
            {
                // An enemy is found within the specified radius
                return true;
            }
        }

        // No enemy found within the specified radius
        return false;
    }
}
