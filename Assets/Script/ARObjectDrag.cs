using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class ARObjectDrag : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 screenOffset;
    private Vector3 fingerPosition; // Declare it here at class level

    private void OnFingerDown(LeanFinger finger)
    {
        if (!isDragging)
        {
            // Check if this finger is touching this object
            if (finger.IsOverGui == false)
            {
                // Convert the Vector2 finger.ScreenPosition to a Vector3
                fingerPosition = finger.ScreenPosition;
                fingerPosition.z = 10f; // Set the appropriate z-coordinate based on your scene

                // Calculate the screen offset from the touch position to the object's position
                screenOffset = Camera.main.WorldToScreenPoint(transform.position) - fingerPosition;
                isDragging = true;
            }
        }
    }

    private void OnFingerUp(LeanFinger finger)
    {
        if (isDragging)
        {
            isDragging = false;
        }
    }

    private void OnDrag(LeanFinger finger)
    {
        if (isDragging)
        {
            // Use the same fingerPosition that was calculated in OnFingerDown
            Vector3 targetPosition = fingerPosition + screenOffset;
            transform.position = Camera.main.ScreenToWorldPoint(targetPosition);
        }
    }
}
