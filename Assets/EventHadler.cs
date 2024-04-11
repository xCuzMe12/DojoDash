using System.Collections;
using System.Collections.Generic;
using UnityEngine;




public class EventHadler : MonoBehaviour
{
    private static EventHadler instance;

    //ABILITIJI
    public ScriptableObject[] abilityAdaptive;
    public ScriptableObject[] abilityUtility;
    public ScriptableObject[] abilityPower;

    public Sprite[] PowerSprites;
    public Sprite[] UtilitySprites;
    public Sprite[] AdaptiveSprites;

    public int[] PowerPrice;
    public int[] UtilityPrice;
    public int[] AdaptivePrice;

    //vse kar rab biti crossScene
























































    public static EventHadler Instance
    {
        get { return instance; }
    }

    void Awake()
    {

        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {

            Destroy(gameObject);
        }
    }
}
