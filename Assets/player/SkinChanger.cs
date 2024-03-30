using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{

    public Sprite[] skini;
    private SpriteRenderer sr;
    private int StevilkaSkina;
    private float speed;
    // Start is called before the first frame update
    void Start()
    {
        StevilkaSkina = 0;
        sr = transform.Find("skin").GetComponent<SpriteRenderer>();
        sr.sprite = skini[StevilkaSkina];

        ChangeSkin(StevilkaSkina);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSkin(int StevilkaSkina)
    {
        if (StevilkaSkina >= skini.Length)
        {
            StevilkaSkina = 0;
        }

        sr.sprite = skini[StevilkaSkina];


    }
    //Help z invizibilitijom
    public void DisableSkin(float howLong, float speedBoostDisable)
    {
        sr.enabled = false;
        speed = speedBoostDisable;
        StartCoroutine(EnableSkin(speed));
    }
    IEnumerator EnableSkin(float speedDisable)
    {
        yield return new WaitForSeconds(5f);
        sr.enabled = true;
        GetComponent<playerMovement>().speed -= speedDisable;
    }
}