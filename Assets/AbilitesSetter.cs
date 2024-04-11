using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class AbilitesSetter : MonoBehaviour
{

    GameObject eventHandler;
    EventHadler eventScript;
    void Start()
    {
        eventHandler = GameObject.FindGameObjectWithTag("EventHandler");
        eventScript = eventHandler.GetComponent<EventHadler>();
    }
    public void BackToMenu()
    {
        SceneManager.LoadScene(0);
    }

    //abilites -POWER
    public ScriptableObject[] MegaBullet;
    public ScriptableObject[] Bomb;
    public ScriptableObject[] abilityPower; //za naprej
    public void MegaBulletButton() //nared za vse 3 type
    {
        eventScript.abilityPower = MegaBullet;
    }
    public void BombButton()
    {
        eventScript.abilityPower = Bomb;
    }

    // abilites -UTILITY (ITEMI, OBEKTI)
    public ScriptableObject[] Turret;
    public ScriptableObject[] GrapplingHook;

    public void TurretButton()
    {
        eventScript.abilityUtility = Turret;
    }
    public void GrapplingButton()
    {
        eventScript.abilityUtility = GrapplingHook;
    }

    // abilites -BOOST











}
