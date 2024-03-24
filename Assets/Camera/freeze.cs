using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class freeze : MonoBehaviour
{
    void Update()
    {
        // Freeze rotation by resetting it to its initial rotation
        transform.rotation = Quaternion.identity;
    }
}
