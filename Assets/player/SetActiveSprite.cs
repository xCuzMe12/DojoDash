using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetActiveSprite : MonoBehaviour
{
    
    SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void DeactiveSprite(float duration)
    {
        StartCoroutine(ResetCoroutine(duration));
    }

    private IEnumerator ResetCoroutine(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        spriteRenderer.enabled = true;
    }
}
