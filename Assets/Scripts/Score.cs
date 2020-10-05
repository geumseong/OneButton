using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Score : MonoBehaviour
{
    int score;
    int lives;
    public GameObject scoreText;
    public GameObject livesText;
    public GameObject gameOverMenu;

    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 5;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScoreUp(){
        score++;
        scoreText.GetComponent<Text>().text = "Score: " + score;
    }

    public void LivesDown(){
        lives--;
        livesText.GetComponent<Text>().text = "Lives: " + lives;
        if(lives == 0){
            Time.timeScale = 0f;
            gameOverMenu.SetActive(true);
        }
    }
}
