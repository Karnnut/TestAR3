using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Touch;

public class Restart : MonoBehaviour
{
    public Button yourButton; // Reference to your UI button

    // References to Timer and ScoreManager scripts
    public Timer timerScript;
    public ScoreManager scoreManagerScript;

    private void OnEnable()
    {
        LeanTouch.OnFingerTap += HandleFingerTap;
    }

    private void OnDisable()
    {
        LeanTouch.OnFingerTap -= HandleFingerTap;
    }

    private void HandleFingerTap(LeanFinger finger)
    {
        if (yourButton != null && yourButton.interactable && finger.IsOverGui)
        {
            RectTransform buttonRect = yourButton.GetComponent<RectTransform>();
            Vector2 localPoint;

            RectTransformUtility.ScreenPointToLocalPointInRectangle(buttonRect, finger.ScreenPosition, null, out localPoint);

            if (buttonRect.rect.Contains(localPoint))
            {
                yourButton.onClick.Invoke();
                RestartScripts();
            }
        }
    }

    private void RestartScripts()
    {
        // Call the reset methods on Timer and ScoreManager
        timerScript.ResetTimer();
        scoreManagerScript.ResetScore();
    }
}
