using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveObject : MonoBehaviour
{
    private bool isDragging = false;
    private Vector3 offset;
    private Camera arCamera;

    void Start()
    {
        arCamera = Camera.main; // Get the AR camera
    }

    void Update()
    {
        if (isDragging)
        {
            // Calculate the new position based on touch/mouse input
            Vector3 newPosition = GetInputWorldPos() + offset;

            // Move the object to the new position
            transform.position = newPosition;
        }
    }

    private Vector3 GetInputWorldPos()
    {
        // Check for touch input
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0); // Get the first touch

            // Check if it's a phase where the object can be dragged
            if (touch.phase == TouchPhase.Began || touch.phase == TouchPhase.Moved)
            {
                // Convert touch position to world space
                Vector3 touchPos = arCamera.ScreenToWorldPoint(touch.position);
                touchPos.z = transform.position.z;

                return touchPos;
            }
        }
        // Check for mouse input
        else if (Input.GetMouseButton(0))
        {
            // Convert mouse position to world space
            Vector3 mousePos = arCamera.ScreenToWorldPoint(Input.mousePosition);
            mousePos.z = transform.position.z;

            return mousePos;
        }

        // No valid input
        return transform.position;
    }

    private void OnMouseDown()
    {
        // Calculate the offset between the object's position and the touch/mouse position
        offset = transform.position - GetInputWorldPos();
        isDragging = true;
    }

    private void OnMouseUp()
    {
        isDragging = false;
    }
}
