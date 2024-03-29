using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//UPG2 OD 2VZPOREDNA - LETITA V TOÈKA, KJER MAS MISKO
public class Shooting21 : MonoBehaviour
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

    private Shooting11 shooting;




    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        stats = player.GetComponent<Stats>();
        shooting = GetComponent<Shooting11>();


    }

    void OnEnable()
    {
        shooting = GetComponent<Shooting11>(); //to res pazi

        bullet = shooting.bullet;
        bulletTransform = shooting.bulletTransform;
        player = shooting.player;
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
            SpawnBulletL(0f, 1f);
            SpawnBulletR(0f, 1f);
        }


        if ((Input.GetMouseButtonDown(0) && CanFire))
        {
            CanFire = false;
            SpawnBulletL(0f, 0.5f);
            SpawnBulletR(0f, 0.5f);

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
    void SpawnBulletL(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position - bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }

    void SpawnBulletR(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position + bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 * offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
    }
}

