using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StateManager : MonoBehaviour
{
    public GameObject menu;
    bool menuOpen = false;
    public GameObject scoreText;
    public GameObject livesText;
    int livesCounter;
    int scoreCounter;
    public GameObject gameOverMenu;
    public GameObject mainMenu;
    public GameObject creditMenu;


    // Start is called before the first frame update
    void Start()
    {
        scoreCounter = 0;
        livesCounter = 5;
        scoreText.GetComponent<Text>().text = "Score: " + scoreCounter;
        livesText.GetComponent<Text>().text = "Lives: " + livesCounter;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            OpenCloseMenu();
        }
    }

    public void OpenCloseMenu(){
        if(menuOpen == true) {
            menu.SetActive(false);
            menuOpen = false;
            Time.timeScale = 1f;
        }
        else {
            menu.SetActive(true);
            menuOpen = true;
            Time.timeScale = 0f;
        }
    }
    public void RestartGame(){
        Time.timeScale = 1f;
        SceneManager.LoadScene("SampleScene");
    }

    public void Resume(){
        menu.SetActive(false);
        menuOpen = false;
        Time.timeScale = 1f;
    }

    public void Quit(){
        Application.Quit();
    }

    public void OpenCredit(){
        mainMenu.SetActive(false);
        creditMenu.SetActive(true);
    }

    public void CloseCredit(){
        mainMenu.SetActive(true);
        creditMenu.SetActive(false);
    }

}
