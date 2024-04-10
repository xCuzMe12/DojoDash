using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public float angleOffset;
    private Vector3 _kam_streljati;
    private bool _kamStreljatiSet = false;
    public SpriteRenderer skin;


    //CE HOCS DA NE STRELJVA V SMER MISKE, SETTAS KamStreljati
    public Vector3 KamStreljati
    {
        get { return _kam_streljati; }
        set
        {
            _kam_streljati = value;
            _kamStreljatiSet = true;
        }
    }

    private GameObject player;
    [HideInInspector] public Stats stats;
    [HideInInspector] public float bulletSpeed;
    [HideInInspector] public int damage;


    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public int lifetime;
    public float ASpeedChange;
    public int damageChange;
    [HideInInspector]public float rotationSpeed;
    Vector3 direction;


    void Start()
    {
        //da das metku speed pa dmg vsakic k se spawna
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
        damage = stats.damage + damageChange;
        bulletSpeed = stats.bulletSpeed;


        if (!_kamStreljatiSet)
        {
            mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
            mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
            direction = mousePos - transform.position;
        }
        else
        {
            direction = _kam_streljati;
        }


        float angleToTarget = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;
        angleToTarget += angleOffset;

        Vector3 rotatedDirection = Quaternion.Euler(0, 0, angleToTarget) * Vector3.right;

        rb.velocity = rotatedDirection.normalized * bulletSpeed;

        if (rotationSpeed > 0)
        {
            StartCoroutine(RotateShuriken());
        }
        else
        {
            transform.rotation = Quaternion.Euler(0, 0, angleToTarget + 90);
        }
        StartCoroutine(Destruction());
         
    }



    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(lifetime); //yield return pr coroutinah 
                                                   //fja odsteva tok sec k je inpol gre naprej po kodi

        
        Destroy(gameObject);
    }
    IEnumerator RotateShuriken()
    {
        while (true)
        {
            transform.Rotate(Vector3.forward * rotationSpeed * Time.deltaTime, Space.Self);
            yield return null;
        }
    }


    void OnCollisionEnter2D(Collision2D collision) 
    {
            Destroy(gameObject);     
    }
}
