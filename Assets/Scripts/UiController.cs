using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UiController : MonoBehaviour
{
    public static UiController instance;
    public GameObject zigzagPanel;
    public GameObject gameoverPanel;
    public GameObject tapText;
    public Text score;
    public Text highScore1;     // highscore in zigzag panel
    public Text highScore2;     // highscore in gameover panel

    void Awake() {
        if(instance == null) {
            instance = this;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        highScore1.text = "High Score: " + PlayerPrefs.GetInt("highScore");
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameStart() {
        tapText.SetActive(false);   // disables the tapText blink on game start
        zigzagPanel.GetComponent<Animator>().Play("MoveUp");    // plays the animation of MoveUp of zigzagPanel
    }

    public void GameOver() {
        score.text = PlayerPrefs.GetInt("score").ToString();
        highScore2.text = PlayerPrefs.GetInt("highScore").ToString();
        gameoverPanel.SetActive(true);  // directly plays the slide in animation of gameover panel
    }

    public void Reset() {
        SceneManager.LoadScene(0);  // Loads the 0th scene, in this case Level1
    }
}
