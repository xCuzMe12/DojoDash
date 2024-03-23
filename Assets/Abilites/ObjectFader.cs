using UnityEngine;

public class ObjectFader : MonoBehaviour
{
    public float fadeDuration = 1f; // Duration of the fade in seconds
    private float fadeTimer = 0f;
    private Renderer rend;

    void Start()
    {
        rend = GetComponent<Renderer>();
    }

    void Update()
    {
        fadeTimer += Time.deltaTime;
        float alpha = 1f - (fadeTimer / fadeDuration); // Calculate alpha value based on time

        
        alpha = Mathf.Clamp01(alpha); //daje value skos med 0 pa 1

        
        Color color = rend.material.color;
        color.a = alpha; //barva.a je alpha - to je transparency in mu mi v updatu damo skos manso alfo
        rend.material.color = color;

        // If fading is complete, destroy the object
        if (fadeTimer >= fadeDuration)
        {
            Destroy(gameObject);
        }
    }
}