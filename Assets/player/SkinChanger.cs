using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkinChanger : MonoBehaviour
{

    public Sprite[] skini;
    private SpriteRenderer sr;
    private int StevilkaSkina;
    // Start is called before the first frame update
    void Start()
    {   
        StevilkaSkina = 1;
        sr = GetComponent<SpriteRenderer>();
        sr.sprite = skini[StevilkaSkina];

        ChangeSkin(StevilkaSkina);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ChangeSkin(int StevilkaSkina)
    {
        if(StevilkaSkina > skini.Length)
        {
            StevilkaSkina = 0;
        }
        Debug.Log("Skin se zamena v " + skini[0]);
        sr.sprite = skini[StevilkaSkina];

    }
}
