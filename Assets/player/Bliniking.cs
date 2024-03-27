using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bliniking : MonoBehaviour
{

    private SpriteRenderer skinSpriteRenderer;
    private bool jeZeDmg = false;

    void Start()
    {
        Transform skinTransform = transform.Find("skin");
        skinSpriteRenderer = skinTransform.GetComponent<SpriteRenderer>();
    }


    //BLINK CE SE ENEMY ZABIE
    void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (collision.gameObject.CompareTag("Enemy") && !jeZeDmg)
        {
            StartCoroutine(BlinkRed());
        }
    }

    IEnumerator BlinkRed()
    {

        jeZeDmg = true;


        Color redWithOpacity = new Color(1f, 0f, 0f, 0.8f); 
        skinSpriteRenderer.color = redWithOpacity;

        yield return new WaitForSeconds(0.1f);


        skinSpriteRenderer.color = Color.white;
        jeZeDmg = false;
    }
}
