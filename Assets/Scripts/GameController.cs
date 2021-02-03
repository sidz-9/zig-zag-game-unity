using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;      // to use as singleton
    public bool gameOver;

    void Awake() {
        if(instance == null) {
            instance = this;        // set as singleton
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame() {
        UiController.instance.GameStart();
        ScoreController.instance.StartScore();
    }

    public void StopGame() {
        UiController.instance.GameOver();
        ScoreController.instance.StopScore();
    }
}
