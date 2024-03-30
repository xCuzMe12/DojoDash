using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//UPG1 2VZPOREDNA - letita vzporedno
public class Shooting11 : MonoBehaviour
{
    private Camera mainCam;
    private Vector3 mousePos;
    [HideInInspector]public GameObject bullet;
    [HideInInspector]public Transform bulletTransform;
    public bool CanFire;
    private float timer;
    public bool autofire = false;


    [HideInInspector]public GameObject player;
    private Stats stats;

    private Shooting shooting;




    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        stats = player.GetComponent<Stats>();
        shooting = GetComponent<Shooting>();


    }

    void OnEnable()
    {
        shooting = GetComponent<Shooting>();

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
            SpawnBulletL(0f, 0.5f);
            SpawnBulletR(0f, 0.5f);
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
        newBullet.GetComponent<bullet>().KamStreljati = mousePos - transform.position;
    }

    void SpawnBulletR(float angleOffset, float offsetDistance)
    {
        Vector3 spawnPosition = transform.position + bulletTransform.right * offsetDistance * 0.8f + bulletTransform.up * 2 *offsetDistance;
        GameObject newBullet = Instantiate(bullet, spawnPosition, Quaternion.identity);
        newBullet.GetComponent<bullet>().angleOffset = angleOffset;
        newBullet.GetComponent<bullet>().KamStreljati = mousePos - transform.position;
    }
}
