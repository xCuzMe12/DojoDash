using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player;
    public GameObject autofireText;
    public bool autofire = false;


    // Start is called before the first frame update
    void Start()
    {

        if (autofireText != null)
            autofireText.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
        if (Input.GetKeyDown("x"))
        {
            autofire = !autofire; //tko sam switchas bool, CRAZY
            if (autofireText != null)
                autofireText.SetActive(autofire); // nastimas text na true/false, based na autofire
        }
    }
}
