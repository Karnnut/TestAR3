using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DestroyObj : MonoBehaviour
{
    public TextMesh scoreText;
    private int score = 0;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasketBall"))
        {
            // Increase the score when the basketball enters the trigger
            score += 1;
            UpdateScoreText();
        }
    }

    private void UpdateScoreText()
    {
        // Update the TMP text with the current score
        scoreText.text = "Score: " + score.ToString();
    }
}
