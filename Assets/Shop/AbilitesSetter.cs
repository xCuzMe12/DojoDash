using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.GraphicsBuffer;



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
    int[] BombPrice;
    public void BombButton()
    {
        eventScript.abilityPower = Bomb;
    }

    // abilites -UTILITY (ITEMI, OBEKTI)
    public ScriptableObject[] Dummy;
    public Sprite[] DummySprites;
    int[] DummyPrice = {100, 150, 250};
    public void DummyButton()
    {
        eventScript.abilityUtility = Dummy;
        eventScript.UtilitySprites = DummySprites;
        eventScript.UtilityPrice = DummyPrice;
        utilitySelected.sprite = DummySprites[0];
    }


    public ScriptableObject[] GrapplingHook;

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
