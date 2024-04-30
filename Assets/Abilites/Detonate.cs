using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class Detonate : MonoBehaviour
{

    public float timer = 4;
    public float blastRadius;
    public int damage = 20;
    public Sprite[] phases;


    private GameObject player;  
    private float currTime = 0;
    private SpriteRenderer sr;
    private Transform tr;
    private Transform childTrans;
    private SpriteRenderer childSprite;
    HashSet<string> enemySet = new HashSet<string> { "Enemy", "Enemy2", "Enemy3", "Enemy4", "Enemy5", "Enemy6" };
    private Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
        childTrans = transform.Find("Explosion");
        childTrans.transform.localScale = new Vector3(blastRadius * 1.26f, blastRadius * 1.26f, 1);
        childSprite = childTrans.GetComponent<SpriteRenderer>();
        childSprite.enabled = false;
        sr = GetComponent<SpriteRenderer>();
        if(transform.parent != null)
        {
            player = gameObject.transform.parent.gameObject;
            gameObject.transform.SetParent(null);
        }
        

        StartCoroutine(Explode(timer));
    }

    void Update()
    {
        currTime += Time.deltaTime;

         if (currTime > 0.33 * timer || currTime > 0.66 * timer)
        {
            sr.sprite = phases[1];
            StartCoroutine(HeatUp(0.3f));
        }else if(currTime > timer - 0.5)
        {              
            sr.sprite = phases[1];
            StartCoroutine(HeatUp(0.3f));
        }

        if (gameObject != null)
        {
            if (Input.GetMouseButtonDown(0))
            {

                offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }

            if (Input.GetMouseButton(0))
            {
                Vector3 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition) + offset;
                newPosition.z = 0f; 
                gameObject.transform.position = newPosition;
            }

            if (Input.GetMouseButtonUp(0))
            {
                // Perform any action upon releasing the bomb, if needed
            }
        }
    }


    IEnumerator HeatUp(float x)
    {
        yield return new WaitForSeconds(x);
        sr.sprite = phases[0];

    }
    IEnumerator Explode(float x)
    {
        yield return new WaitForSeconds(x);
        childSprite.enabled = true;
        sr.enabled = false;
        Damage(blastRadius, damage);
        StartCoroutine(Remove(0.5f));
            }
    IEnumerator Remove(float x)
    {
        yield return new WaitForSeconds(x);
        Destroy(gameObject);
    }

    public void Damage(float radius, int damage)
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, radius/2f);

        if (colliders.Length > 0)
        {
 
            foreach (Collider2D collider in colliders)
            {
                if (enemySet.Contains(collider.gameObject.tag))
                {
                    EnemyMovement enemy = collider.gameObject.GetComponent<EnemyMovement>();
                    
                    enemy.enemyHealth -= damage;
                    if (enemy.enemyHealth < 0)
                    {
                        
                        if (player != null)
                        {
                            EnemyMovement em = enemy.gameObject.GetComponent<EnemyMovement>();
                            Stats stats = player.GetComponent<Stats>();
                            OnDestroy(stats, em);
                        }

                        Destroy(enemy.gameObject);
                    }
                }
                else if (collider.gameObject.CompareTag("Player"))
                {
                    Stats stats = collider.gameObject.GetComponent<Stats>();
                    stats.maxHealth -= damage;
                }
                

            }

        }
    }
    void OnDestroy(Stats stats, EnemyMovement em)
    {   

        stats.kills++;
        stats.gold += em.enemyGold;
        stats.statsDisplay.Display();
        stats.currentXp += em.enemyXP;
        stats.xpBar.SetXP(stats.currentXp);
        stats.xpBar.LevelDisplay(stats.lvl);
        

    }
}
