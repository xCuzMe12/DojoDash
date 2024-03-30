using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour
{
    public GameObject upgSystem;
    public void OpenUpgradeScreen(int stage)
    {

            GameObject upgPath = null;
            switch (stage)
            {
                case 1:
                    upgPath = upgSystem.transform.Find("upg1")?.gameObject;
                    
                    break;
                case 2:
                    upgPath = upgSystem.transform.Find("upg2")?.gameObject;
                    break;
                case 3:
                    upgPath = upgSystem.transform.Find("upg3")?.gameObject;
                    break;
                default:
                    Debug.LogWarning("Invalid stage number.");
                    break;
            }
            upgPath.SetActive(true);
    }
}

