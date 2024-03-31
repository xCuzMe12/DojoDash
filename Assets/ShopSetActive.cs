using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopSetActive : MonoBehaviour
{
    public GameObject shopObject;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Tab))
        {

            shopObject.SetActive(true);
        }
    }
}
