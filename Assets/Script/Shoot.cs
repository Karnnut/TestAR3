using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Touch;

public class Shoot : MonoBehaviour
{
    public GameObject ballPrefab;
    public float shootForce;

    private Vector3 startPosition;
    private bool shooting = false;

    private void OnEnable()
    {
        // Hook into the swipe event when the script is enabled
        LeanTouch.OnFingerSwipe += OnFingerSwipe;
    }

    private void OnDisable()
    {
        // Unhook from the swipe event when the script is disabled
        LeanTouch.OnFingerSwipe -= OnFingerSwipe;
    }

    private void OnFingerSwipe(LeanFinger finger)
    {
        if (!shooting)
        {
            startPosition = finger.GetStartWorldPosition(1.0f);

            // Calculate the shooting direction based on the swipe (use camera's forward direction)
            Vector3 cameraForward = Camera.main.transform.forward;
            Vector3 shootingDirection = new Vector3(cameraForward.x, 0, cameraForward.z).normalized;

            // Spawn a new ball at the shooting position
            GameObject newBall = Instantiate(ballPrefab, startPosition, Quaternion.identity);

            // Apply force to the ball to shoot it as a projectile
            Rigidbody rb = newBall.GetComponent<Rigidbody>();
            rb.AddForce(shootingDirection * shootForce, ForceMode.Impulse);
            rb.AddForce(Vector3.up * shootForce, ForceMode.Impulse); // Add some upward force for a natural arc

            shooting = true;

            // Reset the shooting flag after a delay (adjust as needed)
            Invoke("ResetShooting", 1.0f);
        }
    }

    private void ResetShooting()
    {
        shooting = false;
    }
}
