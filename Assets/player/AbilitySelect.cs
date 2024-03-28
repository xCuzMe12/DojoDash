using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbilitySelect : MonoBehaviour
{
    public GameObject clickablePrefab; // Reference to the clickable prefab to spawn
    public string targetTag = "Clickable"; // Define the tag to identify clickable objects
    public Camera playerCamera; // Reference to the camera belonging to the player who can see the clickable object


    private Boolean ableToClick;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (ableToClick)
        {
            if (Input.GetMouseButtonDown(0))
            {
                // Cast a ray from the mouse position using the player's camera
                Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;

                // Perform the raycast without checking if it hits anything
                Physics.Raycast(ray, out hit);

                // Check if the Collider belongs to an object with the desired tag
                if (hit.collider != null && hit.collider.CompareTag(targetTag))
                {
                    // Object with desired tag has been clicked
                    Debug.Log("Object Clicked: " + hit.collider.gameObject.name);
                    ableToClick = false;

                    // You can perform any desired actions here
                    // For example, you might call a method on the clicked object
                    hit.collider.gameObject.SendMessage("OnClick", SendMessageOptions.DontRequireReceiver);
                }
                else
                {
                    Debug.Log("Napacen tag ig");
                    if(hit.collider == null)
                    {
                        Debug.Log("RIP, hit collider = null");
                    }
                }
            }


        }
        
    }

    

    public void SelectAbility(int lvl)
    {
        Vector3 spawnPosition = new Vector3(0, 0, 0); // Set your desired spawn position
        GameObject clickableObject = Instantiate(clickablePrefab, spawnPosition, Quaternion.identity);
        clickableObject.tag = targetTag; // Set the tag of the spawned object
        ableToClick = true;
        Debug.Log("Able to click" + ableToClick);
    }

    public void DetectClick()
    {
        // Check if the left mouse button is clicked
        if (Input.GetMouseButtonDown(0))
        {
            // Cast a ray from the mouse position using the player's camera
            Ray ray = playerCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            // Check if the ray intersects with any Collider visible to the player's camera
            if (Physics.Raycast(ray, out hit))
            {
                // Debug log to check which object was hit by the ray
                Debug.Log("Ray hit object: " + hit.collider.gameObject.name);

                // Check if the Collider belongs to an object with the desired tag
                if (hit.collider.CompareTag(targetTag))
                {
                    // Object with desired tag has been clicked
                    Debug.Log("Object Clicked: " + hit.collider.gameObject.name);
                    ableToClick = false;
                    

                    // You can perform any desired actions here
                }
            }
            else
            {
                // Debug log if no object was hit by the ray
                Debug.Log("Ray hit nothing.");
            }
        }
    }
}
