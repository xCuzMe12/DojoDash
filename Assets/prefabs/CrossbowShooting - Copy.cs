using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class CrossbowShooting : MonoBehaviour
{

    //public GameObject owner; // The owner of this object
    public float aliveTime;
    public GameObject particlePrefab; // The particle prefab to shoot
    public string[] targetTags; // Array of tags of the targets you want to shoot
    public float shootingRange = 10f; // Maximum distance to look for targets
    public float FireSpeed;
    private float currentTime;
    bool wayOfShooting = true;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(DeathTimer(aliveTime));
    }

    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= FireSpeed)
        {   
            currentTime = 0;
            GameObject nearestTarget = FindNearestTarget();

            if (nearestTarget != null)
            {
                ShootAtTarget(nearestTarget.transform.position);
            }
        }

        if (Input.GetKeyDown(KeyCode.N))
        {
            wayOfShooting = !wayOfShooting;
        }
    }

    GameObject FindNearestTarget()
    {
        GameObject nearestTarget = null;
        float minDistance = Mathf.Infinity;

        foreach (string tag in targetTags)
        {
            GameObject[] targets = GameObject.FindGameObjectsWithTag(tag);

            foreach (GameObject target in targets)
            {
                if (target != null && target != gameObject) // Check if target is not null and not the same object as this one
                {
                    float distance = Vector3.Distance(transform.position, target.transform.position);
                    if (distance < minDistance && distance <= shootingRange)
                    {
                        minDistance = distance;
                        nearestTarget = target;
                    }
                }
            }
        }

        return nearestTarget;
    }


    void ShootAtTarget(Vector3 targetPosition)
    {
        if (wayOfShooting) // closest
        {
            GameObject bullet = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            bullet.GetComponent<bullet>().KamStreljati = targetPosition - transform.position;
        }
        else //v smer miske
        {
            Vector3 direction = (targetPosition - transform.position).normalized;
            GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);
            ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();
            if (particleSystem != null)
            {
                particleSystem.Play();
                Destroy(particle, particleSystem.main.duration);
            }
            else
            {
                Destroy(particle);
            }
            Vector3 particleForward = direction;
            particle.transform.rotation = Quaternion.LookRotation(Vector3.forward, particleForward);
        }

    }

    IEnumerator DeathTimer(float x)
    {
        yield return new WaitForSeconds(x);
        Destroy(gameObject);
    }
}