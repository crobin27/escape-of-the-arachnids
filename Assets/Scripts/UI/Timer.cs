using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Timer : MonoBehaviour
{
    public static float timeSpent = 0;
    private TMP_Text timerText;
    public static bool isPaused = false;

    void Start()
    {
        // Get the TMP_Text component
        timerText = GetComponent<TMP_Text>();
        // set timeSpent to 0 when the game starts

        // Start the UpdateTime coroutine
        StartCoroutine(UpdateTime());
    }

    IEnumerator UpdateTime()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);

            // If the game isn't paused, increment the timer
            if (!isPaused)
            {
                timeSpent++;
            }

            // Convert the time spent to minutes and seconds
            int minutes = Mathf.FloorToInt(timeSpent / 60);
            int seconds = Mathf.FloorToInt(timeSpent % 60);

            // Modify the string format based on the minutes
            if (minutes < 10)
            {
                timerText.text = string.Format("{0}:{1:00}", minutes, seconds);
            }
            else
            {
                timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            }
        }
    }
}
