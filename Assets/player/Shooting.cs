using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//REPI PAZI - TE 4 OSNOVNI VSI INHERITAJO IZ TEGA, UNI LVL2 UPGRADE PA IZ LVL1 NE IZ TEGA

public class Shooting : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    public GameObject bullet;
    public Transform bulletTransform;
    public bool CanFire;
    private float timer;
    public bool autofire = false;

    public int upgtype = 00;

    public GameObject player;
    private Stats stats;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        stats = player.GetComponent<Stats>();


    }

    void Update()
    {
        //sledenje miski
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
 
        Vector3 rotation = mousePos - transform.position;


        float rotZ = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.Euler(0, 0, rotZ);

        //autofire
        if (Input.GetKeyDown("x"))
        {
            autofire = !autofire; //tko sam switchas bool, CRAZY
         }

        //stel
        if (autofire && CanFire)
        {
            CanFire = false;
            Shoot(upgtype);
        }


        if ((Input.GetMouseButtonDown(0) && CanFire))
        {
            CanFire = false;
            Shoot(upgtype);
        }

        //reload
        if (!CanFire)
        {
            timer += Time.deltaTime;
                if (timer > stats.attackSpeed)
            {
                CanFire = true;
                timer = 0;
            }
        }




    }
    public void Shoot(int upg)
    {
        switch (upg)
        {
            //TIER I
            case 00:
                SpawnBullet(0f);
                break;
            case 11:
                SpawnBullet11L(0f, 0.5f);
                SpawnBullet11R(0f, 0.5f);
                break;
            case 12:
                SpawnBullet(0f);
                SpawnBullet(30f);
                SpawnBullet(-30f);
                break;
            case 13:
                StartCoroutine(Pavza(0.05f));
                break;
            case 14:
                //DVA NAZAJ
                break;


            //TIER II
            case 21:
                SpawnBullet21L(0f, 0.5f);
                SpawnBullet21R(0f, 0.5f);
                break;
            case 22:
                break;
            case 23:
                break;
            case 24:
                break;

        }
    }
    //basic, 12, vse k so dependant na mousepos
    void SpawnBullet(float angleOffset) 
    {
        GameObject newBullet = Instantiate(bullet, transform.position + bulletTransform.up * 1f, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }

    //11
    void SpawnBullet11L(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position - bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
        newBullet.GetComponent<bullet>().KamStreljati = mousePos - transform.position;
    }
    void SpawnBullet11R(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position + bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
        newBullet.GetComponent<bullet>().KamStreljati = mousePos - transform.position;
    }
    //13
    IEnumerator Pavza(float cas)
    {
        SpawnBullet(0f);
        yield return new WaitForSeconds(cas);
        SpawnBullet(0f);
    }



    //TIER II
    //21
    void SpawnBullet21L(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position - bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }

    void SpawnBullet21R(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position + bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }



}
