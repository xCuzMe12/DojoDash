using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField] public PowerupEffect speedboost;
    [SerializeField] public PowerupEffect heal;
    [SerializeField] public PowerupEffect damageboost;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Stats stats = collision.gameObject.GetComponent<Stats>();

        //ce ma to komponento
        if (stats != null)
        {
            if (speedboost != null)
            {
                if (collision.gameObject.tag == "Player")
                {
                    Destroy(gameObject);
                    speedboost.Apply(collision.gameObject);
                }
            }
            else if (heal != null)
            {
                int currentHp = stats.currentHealth;
                int maxHp = stats.maxHealth;

                if (collision.gameObject.tag == "Player" && currentHp < maxHp)
                {
                    Destroy(gameObject);
                    heal.Apply(collision.gameObject);
                }
            }
            else if (damageboost != null)
            {
                return; //to se zrihti
            }


        }

    }


}
