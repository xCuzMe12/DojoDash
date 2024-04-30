using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grappling : MonoBehaviour
{

    LineRenderer line;
    [SerializeField] LayerMask grappableMask;
    [SerializeField] float maxDistance = 10f;
    [SerializeField] float grappleSpeed = 10f;
    [SerializeField] float grappleShootSpeed = 80f;
    public float grappleRange = 30;
    private Transform parentTrans;
    private GameObject objectToFollow;
    public float Cooldown = 5f;
    private float currTime;

    bool isGrappling = false;
    [HideInInspector] public bool retracting = false;
    Vector2 target;

    private void Start()
    {
        line = GetComponent<LineRenderer>();
        parentTrans = transform.parent;
        objectToFollow = GameObject.Find("BulletTransform");
        currTime = Cooldown;
    }

    private void LateUpdate()

    {
        currTime += Time.deltaTime;

        if (objectToFollow != null)
        {
            transform.position = objectToFollow.transform.position;
            transform.rotation = objectToFollow.transform.rotation;
            transform.Rotate(Vector3.up, -90f);
        }
        else
        {
            Debug.Log("Ni rotate pointa!");
        }


        if (Input.GetMouseButtonDown(1) && !isGrappling && currTime >= Cooldown)
        {
            currTime = 0;
            StartGrapple();
        }
        if (retracting)
        {
            Vector2 grapplePos = Vector2.Lerp(parentTrans.position, target, grappleSpeed * Time.deltaTime);
            parentTrans.position = grapplePos;
            line.SetPosition(0, parentTrans.position);
            if (Vector2.Distance(parentTrans.position, target) < 0.5f)
            {
                retracting = false;
                isGrappling = false;
                line.enabled = false;
            }

        }


    }
    private void StartGrapple()
    {
        Vector2 startPos = (Vector2)transform.position;
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = mousePosition - startPos;

        RaycastHit2D hit = Physics2D.Raycast(startPos, direction.normalized, maxDistance, grappableMask);

        if (hit.collider != null)
        {
            isGrappling = true;
            target = hit.point;
            line.enabled = true;
            line.positionCount = 2;

            StartCoroutine(Grapple());
        }
    }

    IEnumerator Grapple()
    {
        Vector2 startPos = transform.position;
        float distance = Vector2.Distance(startPos, target);
        float duration = distance / grappleShootSpeed;
        float elapsedTime = 0;


        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float t = elapsedTime / duration;
            Vector2 newPos = Vector2.Lerp(startPos, target, t);
            line.SetPosition(0, parentTrans.position);
            line.SetPosition(1, newPos);
            yield return null;
        }

        line.SetPosition(1, target);
        retracting = true;
    }
    
}
