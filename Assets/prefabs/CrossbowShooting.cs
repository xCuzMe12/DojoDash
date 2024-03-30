using System.Collections;
using System.Collections.Generic;
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
            // Find the nearest target
            GameObject nearestTarget = FindNearestTarget();

            // If a target is found, shoot at it
            if (nearestTarget != null)
            {
                ShootAtTarget(nearestTarget.transform.position);
            }
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
                // Check if the target is the owner object
                if (target != null)
                {
                    // Check for collisions with the owner's collider
                    Collider2D targetCollider = target.GetComponent<Collider2D>();
                    //Collider2D ownerCollider = owner.GetComponent<Collider2D>();

                    
                        // Calculate distance between this object and target
                        float distance = Vector3.Distance(transform.position, target.transform.position);
                       
                        // If this target is closer than the current nearest target
                        if (distance < minDistance && distance <= shootingRange)
                        {
                            // Update nearest target and minimum distance
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
        // Calculate the direction towards the target
        Vector3 direction = (targetPosition - transform.position).normalized;

        // Instantiate a particle at the current position
        GameObject particle = Instantiate(particlePrefab, transform.position, Quaternion.identity);

        // Get the particle system from the particle prefab
        ParticleSystem particleSystem = particle.GetComponent<ParticleSystem>();

        // If the particle system is found, play it and destroy the particle after its duration
        if (particleSystem != null)
        {
            particleSystem.Play();
            Destroy(particle, particleSystem.main.duration);
        }
        else
        {
            // If the particle system component is not found, destroy the particle immediately
            Destroy(particle);
        }

        // Rotate the particle towards the target position
        Vector3 particleForward = direction;
        particle.transform.rotation = Quaternion.LookRotation(Vector3.forward, particleForward);
    }
    IEnumerator DeathTimer(float x)
    {

        yield return new WaitForSeconds(x);
        Destroy(gameObject);
    }
}