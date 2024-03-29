using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting11 : MonoBehaviour
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
    private Shooting shooting;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        stats = player.GetComponent<Stats>();
        shooting = GetComponent<Shooting>();

        bulletTransform = shooting.bulletTransform;
        bullet = shooting.bullet;
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
            Instantiate(bullet, transform.position + bulletTransform.up * 1f, Quaternion.identity);
             
        }


        if ((Input.GetMouseButtonDown(0) && CanFire))
        {
            CanFire = false;
            Instantiate(bullet, transform.position + bulletTransform.up * 1f, Quaternion.identity);
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
}
