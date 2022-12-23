using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIManagerScript : MonoBehaviour
{
    public Score score;
    
    public AudioSource gameSound;
    
    public GameObject game;
    public GameObject pause;
    public GameObject gameOver;
    
    public Text gameoverScore;
    public bool gameOverShow;
    
    private void Update()
    {
        if (gameOverShow)
        {
            if (Input.GetKey(KeyCode.Space))
            {
                RestartMenu();
            }
        }
    }

    public void StartGame()
    {
        SceneManager.LoadScene("Game");
    }

    public void GameOver()
    {
        gameSound.Stop();
        pause.SetActive(false);
        game.SetActive(false);
        gameOver.SetActive(true);
        gameOverShow = true;
        gameoverScore.text = score.score.ToString();
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        gameSound.Pause();
        pause.SetActive(true);
        game.SetActive(false);
    }

    public void ResumeGame()
    {
        pause.SetActive(false);
        game.SetActive(true);
        gameSound.Play();
        Time.timeScale = 1;
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void ExitMenu() 
    {
        Application.Quit();
    }

    public void RestartMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}