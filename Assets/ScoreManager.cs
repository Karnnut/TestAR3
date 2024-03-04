using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    [SerializeReference] TextMeshPro score_text;
    private int score;
    private bool canScore = true; // Flag to control scoring
    private float cooldownTime = 1f; // Cooldown time in seconds
    private float lastScoreTime; // Time when last score was made

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("BasketBall") && canScore && Time.time > lastScoreTime + cooldownTime)
        {
            score += 1;
            lastScoreTime = Time.time; // Update last score time
        }
    }

    private void Update()
    {
        score_text.text = score.ToString();
    }

    public void ResetScore()
    {
        score = 0; // Reset score
        lastScoreTime = 0f; // Reset the last score time
        // Any other reset logic...
    }
}
