using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(Bomb))]
public class BombEditor : Editor
{
    private Vector3 mouseOffset;
    private bool isDragging;

    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        Bomb bomb = (Bomb)target;

        // Display a button to activate the bomb ability
        if (GUILayout.Button("Activate Bomb"))
        {
            // Perform any action when activating the bomb, if needed
            // For example, instantiate the bomb at a certain position
            bomb.BombPos = Vector3.zero; // Set bomb position to (0, 0, 0) as an example
        }
    }

    void OnSceneGUI()
    {
        Bomb bomb = (Bomb)target;

        // Check if left mouse button is pressed
        if (Event.current.type == EventType.MouseDown && Event.current.button == 0)
        {
            // Cast a ray from the mouse position to detect bomb
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                // Check if the bomb is clicked
                if (hit.collider.gameObject == bomb)
                {
                    // Calculate the offset between mouse position and bomb position
                    mouseOffset = bomb.BombPos - hit.point;
                    isDragging = true;
                }
            }
        }

        // Check if left mouse button is released
        if (Event.current.type == EventType.MouseUp && Event.current.button == 0)
        {
            isDragging = false;
        }

        // Check if left mouse button is held down and bomb is being dragged
        if (isDragging && Event.current.type == EventType.MouseDrag && Event.current.button == 0)
        {
            // Update bomb position to follow mouse position with offset
            Ray ray = HandleUtility.GUIPointToWorldRay(Event.current.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit))
            {
                bomb.BombPos = hit.point + mouseOffset;
            }
        }
    }
}
