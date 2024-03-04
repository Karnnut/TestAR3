using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using Lean.Touch;

using UnityEngine.SceneManagement;
public class ButtonChangeScene : MonoBehaviour
{public Button yourButton; // Reference to your UI button
    private int sceneToLoad = 1; // Name of the scene to load

    private void OnEnable()
    {
        // Subscribe to the LeanTouch.OnFingerTap event
        LeanTouch.OnFingerTap += HandleFingerTap;
    }

    private void OnDisable()
    {
        // Unsubscribe from the LeanTouch.OnFingerTap event
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        // Check if the UI button is interactable and was tapped
        if (yourButton != null && yourButton.interactable && finger.IsOverGui)
        {
            RectTransform buttonRect = yourButton.GetComponent<RectTransform>();
            Vector2 localPoint;

            // Convert the tap position to the local coordinates of the button
            RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, finger.ScreenPosition, null, out localPoint);

            // Check if the tap occurred within the bounds of the button's RectTransform
            if (buttonRect.rect.Contains(localPoint))
            {
                // Trigger the button click
                yourButton.onClick.Invoke();

                // Load the specified scene
                SceneManager.LoadScene(sceneToLoad);
            }
        }
    }
}
