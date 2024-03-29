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
            SpawnBullet(0f);
        }


        if ((Input.GetMouseButtonDown(0) && CanFire))
        {
            CanFire = false;
            SpawnBullet(0f);
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
    void SpawnBullet(float angleOffset)
    {
        GameObject newBullet = Instantiate(bullet, transform.position + bulletTransform.up * 1f, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }
}
