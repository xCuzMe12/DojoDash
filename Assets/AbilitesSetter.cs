using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class AbilitesSetter : MonoBehaviour
{

    GameObject eventHandler;
    EventHadler eventScript;

    public Image powerSelected;
    public Image utilitySelected;
    public Image adaptiveSelected;


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
    public void MegaBulletButton()
    {
        eventScript.abilityPower = MegaBullet;
        eventScript.PowerSprites = MegaBulletSprites;
        eventScript.PowerPrice = MegaBulletPrice;
        powerSelected.sprite = MegaBulletSprites[0];
    }

    //BOMB
    public ScriptableObject[] Bomb;
    public Sprite[] BombSprites;
    public int[] BombPrice;
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

    // abilites -ADAPTIVE
    //TELEPORT
    public ScriptableObject[] Teleport;
    public Sprite[] TeleportSprites;
    int[] TeleportPrice = { 100, 150, 250 };
    public void TeleportButton()
    {
        eventScript.abilityAdaptive = Teleport;
        eventScript.AdaptiveSprites = TeleportSprites;
        eventScript.AdaptivePrice = TeleportPrice;
        adaptiveSelected.sprite = TeleportSprites[0];
    }














}
