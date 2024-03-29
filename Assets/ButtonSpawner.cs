using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ButtonSpawner : MonoBehaviour
{
    public GameObject player; // Reference to the player GameObject
    public string buttonText = "Upgrade 1"; // Text displayed on the button

    void Start()
    {
        // Create a new button GameObject
        GameObject buttonObj = new GameObject("Button");
        buttonObj.transform.SetParent(transform); // Set the button's parent to this GameObject

        // Add a Canvas component to the button GameObject
        Canvas canvas = buttonObj.AddComponent<Canvas>();
        canvas.renderMode = RenderMode.ScreenSpaceOverlay; // Set render mode to Screen Space Overlay

        // Add a Button component to the button GameObject
        Button button = buttonObj.AddComponent<Button>();

        // Add a Text component to the button GameObject
        Text buttonTextComponent = buttonObj.AddComponent<Text>();
        buttonTextComponent.text = buttonText; // Set the button's text

        // Set the button's position and size using RectTransform
        RectTransform rectTransform = buttonObj.GetComponent<RectTransform>();
        rectTransform.sizeDelta = new Vector2(200, 50); // Set the button's size
        rectTransform.anchoredPosition = Vector2.zero; // Set the button's position to the center of the screen

        // Add a Button Click event listener
        button.onClick.AddListener(OnButtonClick);
    }

    // Method called when the button is clicked
    void OnButtonClick()
    {
        Debug.Log("Button clicked!");
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
