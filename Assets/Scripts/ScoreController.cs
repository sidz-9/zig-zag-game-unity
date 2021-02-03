using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreController : MonoBehaviour
{
    public static ScoreController instance;     // to set as a singleton
    public int score;
    public int highScore;

    void Awake() {
        if(instance == null) {      
            instance = this;        // setting as a singleton reference
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        PlayerPrefs.SetInt("score", score);     // PlayerPrefs enables saving the score value to the system
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void IncrementScore() {
        score++;
    }

    public void StartScore() {      // starts calling the IncrementScore method after 0.1s for every 0.5s
        InvokeRepeating("IncrementScore", 0.1f, 0.5f);
    }

    public void StopScore() {
        CancelInvoke("IncrementScore");     // stops the invoke of IncrementScore

        if(PlayerPrefs.HasKey("highScore"))     // if highScore already exists in system, then check it against the current score
        {
            if(score > PlayerPrefs.GetInt("highScore"))     
            {
                PlayerPrefs.SetInt("highScore", score);     // set score to highScore if current score is greater than highScore
            }
        }
        else 
        {
            PlayerPrefs.SetInt("highScore", score);     // if highScore doesnt exists in system, then simply set the score value to highScore key
        }
    }
}
