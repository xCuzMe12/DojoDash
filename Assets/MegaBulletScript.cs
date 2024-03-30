using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MegaBulletScript : MonoBehaviour
{
    public float angleOffset;
    private Vector3 _kam_streljati;
    private bool _kamStreljatiSet = false;


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
    public float bulletSpeed;
    public int damage;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public int lifetime;

    Vector3 direction;


    void Start()
    {
        //da das metku speed pa dmg vsakic k se spawna
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<Stats>();
        rb = GetComponent<Rigidbody2D>();
       

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


        // Calculate the angle to the target position
        float angleToTarget = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        // Apply the angle offset
        angleToTarget += angleOffset;

        // Convert the angle back to a direction vector
        Vector3 rotatedDirection = Quaternion.Euler(0, 0, angleToTarget) * Vector3.right;

        // Set the bullet's velocity using the rotated direction
        rb.velocity = rotatedDirection.normalized * bulletSpeed;

        // Calculate rotation based on the modified direction
        transform.rotation = Quaternion.Euler(0, 0, angleToTarget + 90);
        StartCoroutine(Destruction());

    }



    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(lifetime); //yield return pr coroutinah 
                                                   //fja odsteva tok sec k je inpol gre naprej po kodi


        Destroy(gameObject);
    }


    /*void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }*/
}
