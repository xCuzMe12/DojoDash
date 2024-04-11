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

    //POWER
    //MEGABULLET
    public ScriptableObject[] MegaBullet;
    public Sprite[] MegaBulletSprites;
    int[] MegaBulletPrice = {75, 100, 125}; //te stvari pazi, k ce spreminjas pol kasnej se loh kej zjebe
    //BOMB
    public ScriptableObject[] Bomb;
    public Sprite[] BombSprites;
    public int[] BombPrice;
    //
    public ScriptableObject[] abilityPower; 

    public void MegaBulletButton() 
    {
        eventScript.abilityPower = MegaBullet;
        eventScript.PowerSprites = MegaBulletSprites;
        eventScript.PowerPrice = MegaBulletPrice;
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
