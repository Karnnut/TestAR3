using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
public class Timer : MonoBehaviour
{
    [SerializeField] TextMeshPro timeText;
    [SerializeField] float remainigTime;
    [SerializeField] float initialTime;

    void Update(){
        if (remainigTime > 0) {
            remainigTime -= Time.deltaTime;
            remainigTime -= Time.deltaTime;
            int minutes = Mathf.FloorToInt(remainigTime / 60);
            int seconds = Mathf.RoundToInt(remainigTime % 60);
            timeText.text = string.Format("{0:00}:{1:00}",minutes, seconds);
        }else if (remainigTime < 0) {
            remainigTime = 0;
            timeText.text = "Time Out!";
            timeText.color = Color.red;
        }

    }

        public void ResetTimer()
    {
        remainigTime = initialTime; // Reset to initial time
        Update();
        // Any other reset logic...
    }
}
