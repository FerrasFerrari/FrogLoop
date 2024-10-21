using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    private float TimeRemaining = 602;
    public bool timeIsRunning = true;
    public TMP_Text timeText;
    
    void Start()
    {
        timeIsRunning = true;
    }
    void Update()
    {
       if(timeIsRunning)
        {
            if(TimeRemaining >= 0)
            {
                TimeRemaining -= Time.deltaTime;
                DisplayTime(TimeRemaining);
            }
            if (TimeRemaining <= 1)
            {
                ResetGame();
            }
        }
       
    }
    void DisplayTime (float timeToDisplay)
    {
        timeToDisplay -= 1;
        float minutes = Mathf.FloorToInt (timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);
        timeText.text = string.Format ("{0:00} : {1:00}", minutes, seconds);
    }
    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
    }
}
