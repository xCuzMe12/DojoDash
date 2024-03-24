using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    //public Transform player;
    public GameObject autofireText;
    public bool autofire = false;


    void Start()
    {

        if (autofireText != null)
            autofireText.SetActive(false);
    }


    void Update()
    {
        //to mas ce bos kdaj rabu kamero izven player parenta
        //transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (Input.GetKeyDown("x"))
        {
            autofire = !autofire; //tko sam switchas bool, CRAZY
            if (autofireText != null)
                autofireText.SetActive(autofire); // nastimas text na true/false, based na autofire
        }
    }
}
