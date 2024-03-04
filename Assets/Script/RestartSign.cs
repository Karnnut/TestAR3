using System.Collections;
using System.Collections.Generic;
using Lean.Touch;
using UnityEngine;
using UnityEngine.UI;


public class RestartSign : MonoBehaviour
{
    public Button yourButton;
    public Transform thai1_pos;
    public Transform thai2_pos;
    public Transform thai3_pos;

    public Transform eng1_pos;
    public Transform eng2_pos;
    public Transform eng3_pos;

    public GameObject thai1;
    public GameObject thai2;
    public GameObject thai3;
    public GameObject eng1;
    public GameObject eng2;
    public GameObject eng3;

    public GameObject effect;


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
                Restart();
            }
        }
    }

    public void Restart()
    {
        thai1.transform.position = thai1_pos.position;
        thai2.transform.position = thai2_pos.position;
        thai3.transform.position = thai3_pos.position;

        eng1.transform.position = eng1_pos.position;
        eng2.transform.position = eng2_pos.position;
        eng3.transform.position = eng3_pos.position;

        effect.SetActive(false);
    }

}
