using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShopManagement : MonoBehaviour
{

    public int speed = 0;
    public int health = 0;
    public int attackSpeed = 0;
    public int bodyDMG = 0;
    public int DMG = 0;
    public int bulletSpeed = 0;
    public int bulletPen = 0;



    void speedUpg()
    {
        speed++;
    }
    void healthUpg()
    {
        health++;
    }
    void attackSpeedUpg()
    {
        attackSpeed++;
    }
    void bodyDMGUpg()
    {
        bodyDMG++;
    }
    void DMGUpg()
    {
        DMG++;
    }
    void bulletSpeedUpg()
    {
        bulletSpeed++;
    }
    void bulletPenUpg()
    {
        bulletPen++;
    }
}
