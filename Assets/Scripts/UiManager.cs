using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour {

    public Button[] buttons;
    public Text scoreText;
    bool gameOver;
    int score;

	// Use this for initialization
	void Start () {
        gameOver = false;
        score = 0;
        InvokeRepeating("scoreUpdate",1.0f,0.4f);
	}
	
	// Update is called once per frame
	void Update () {
        scoreText.text = "Score : " + score;
	}

    void scoreUpdate()
    {
        if (!gameOver)
        {
            score += 1;
        }
    }

    public void Pause()
    {
        if(Time.timeScale == 1)//game is running.
        {
            Time.timeScale = 0;
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(true);
            }
        }
        else if(Time.timeScale == 0)//game is posed.
        {
            Time.timeScale = 1;
            foreach (Button button in buttons)
            {
                button.gameObject.SetActive(false);
            }
        }

        
    }

    public void gameOverActivated()
    {
        gameOver = true;
        foreach(Button button in buttons){
            button.gameObject.SetActive(true);
        }
    }
    public void Play()
    {
        Application.LoadLevel("GameScene");
        //UnityEngine.SceneManagement.SceneManager.LoadScene("GameScene");
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }    

    public void Replay()
    {
        Application.LoadLevel(Application.loadedLevel);
        foreach (Button button in buttons)
        {
            button.gameObject.SetActive(false);
        }
    }
    public void Menu()
    {
        Application.LoadLevel("TitleScene");
    }
    public void Exit()
    {
        Application.Quit();
    }
}
