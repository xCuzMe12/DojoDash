using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    private GameObject player;
    [HideInInspector] public Stats stats;
    public float bulletSpeed;
    [HideInInspector] public int damage;

    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public int lifetime;

    public void Initialize(Vector3 targetPosition, float angleOffset)
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        Quaternion rotation = Quaternion.Euler(0, 0, angleOffset) * Quaternion.LookRotation(Vector3.forward, direction);
        GetComponent<Rigidbody2D>().velocity = rotation * Vector2.right * speed;
    }
    void Start()
    {
        //da das metku speed pa dmg vsakic k se spawna
        player = GameObject.FindGameObjectWithTag("Player");
        stats = player.GetComponent<Stats>();
        damage = stats.damage;
        bulletSpeed = stats.bulletSpeed;



        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition); 
        Vector3 direction = mousePos - transform.position;
        Vector3 rotation = transform.position - mousePos;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * bulletSpeed; //normalized - sam da ne vpliva na bulletSpeed to kok delc je miska
        float rot = Mathf.Atan2(rotation.y, rotation.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);
        StartCoroutine(Destruction());
         
    }

    IEnumerator Destruction()
    {
        yield return new WaitForSeconds(lifetime); //yield return pr coroutinah 
                                                   //fja odsteva tok sec k je inpol gre naprej po kodi

        
        Destroy(gameObject);
    }

    
    void OnCollisionEnter2D(Collision2D collision) 
    {
            Destroy(gameObject);     
    }
}
