using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class playerMovement : MonoBehaviour
{   //SE FUL ZA POPRAVT, USKLADIT DA DELA BOOST SAM K MAS METK, + AUTOFIRE ZRIHTI




    private float shootingSpeedMultiplier = 1.5f;
    float speedX, speedY;
    Rigidbody2D rb;
    [HideInInspector] public Vector2 movementInput;
    [HideInInspector] public Vector2 shootingDirection;

    private bool isBoostActive = false;
    private Shooting shootingScript;

    public Text bonusSpeedText;

    
    private Stats stats;
    //[HideInInspector]
    public float speed;

    public bool boosted = false;


    void Start()
    {


        rb = GetComponent<Rigidbody2D>();
        //da dobis CanFire, importas script
        GameObject point = GameObject.Find("RotatePoint");
        shootingScript = point.GetComponent<Shooting>();

        stats = GetComponent<Stats>();
        speed = stats.speed;
    }



    void FixedUpdate()
    {

        transform.rotation = Quaternion.identity;

        speedX = Input.GetAxisRaw("Horizontal") * speed;
        speedY = Input.GetAxisRaw("Vertical") * speed;
        movementInput = new Vector2(speedX, speedY).normalized;

        
            if (Input.GetMouseButton(0))
            {
                
                isBoostActive = true;
                StartCoroutine(ResetSpeedAfterDelay(stats.attackSpeed));
            }

            if (isBoostActive)
            {

                

                Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                shootingDirection = (mousePos - transform.position).normalized;
                float angle = Vector2.SignedAngle(movementInput, shootingDirection);

                if (angle > 90f || angle < -90f)
                {
                    
                    rb.velocity = movementInput * speed * shootingSpeedMultiplier;

                }
                else
                {
                    

                    rb.velocity = movementInput * (speed / shootingSpeedMultiplier);

                }
            }
            else
            {
                rb.velocity = movementInput * speed;
            }
        



    }
    IEnumerator ResetSpeedAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        isBoostActive = false; 
    }


    public float totalBonusSpeed = 0;
    //speed boost da je na cas
    public void SpeedBoost(int amount, float duration)
    {
        StartCoroutine(ResetSpeedAfterBoost(amount, duration));
    }

    IEnumerator ResetSpeedAfterBoost(int amount, float duration)
    {
        totalBonusSpeed += amount; 
        speed += amount;
        bonusSpeedText.enabled = true; 
        bonusSpeedText.text = "BONUS SPEED +" + totalBonusSpeed.ToString(); 
        yield return new WaitForSeconds(duration);
        speed -= amount;
        totalBonusSpeed -= amount;
        bonusSpeedText.text = "BONUS SPEED +" + totalBonusSpeed.ToString();
        if (totalBonusSpeed <= 0) 
            bonusSpeedText.enabled = false;
    }

    public void UpdateSpeed()
    {
        speed = stats.speed;
    }
}
