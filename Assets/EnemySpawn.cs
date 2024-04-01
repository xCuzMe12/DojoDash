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
    // Start is called before the first frame update
    void Start()
    {
        SpawnProtectionRadius = Mathf.Abs(SpawnProtectionRadius);
        RangeX = Mathf.Abs(RangeX);
        RangeY = Mathf.Abs(RangeY);
    }

    // Update is called once per frame
    void Update()
    {
        CurrentTime += Time.deltaTime;
        if (CurrentTime >= SpawnTimer) {
            CurrentTime = 0;

            int randomX;
            int randomY;
            int i = 0;
            do
            {
                randomX = Random.Range(RangeX * (-1), RangeX + 1);
                i++;
            } while (Mathf.Abs(randomX) * (-1) >= SpawnProtectionRadius * (-1) && Mathf.Abs(randomX) <= SpawnProtectionRadius && i < 50);
            i = 0;
            do
            {
                randomY = Random.Range(RangeY * (-1), RangeY + 1);
            } while (Mathf.Abs(randomY) * (-1) >= SpawnProtectionRadius * (-1) && Mathf.Abs(randomY) <= SpawnProtectionRadius && i < 50);

            GameObject enemy = Enemies[Random.Range(0, Enemies.Length)];


            Vector3 spawnPosition = new Vector3(randomX, randomY, 0);
            Instantiate(enemy, spawnPosition, Quaternion.identity);
            Debug.Log("Spawned at: " + spawnPosition);
        }
    }
}
