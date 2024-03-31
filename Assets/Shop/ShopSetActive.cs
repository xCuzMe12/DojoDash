using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSetActive : MonoBehaviour
{
    GameObject player;
    public GameObject shopObject;
    bool open = false;
    private void Start()
    {
        Transform playerT = transform.parent.parent;
        player = playerT.gameObject;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            if (!open)
            {
                shopObject.SetActive(true);
            }
            else
            {
                shopObject.SetActive(false);
                player.GetComponent<Stats>().statsDisplay.Display();
            }
            open = !open;
        }
    }
}
