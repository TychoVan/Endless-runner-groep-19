using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager   Instance;

    [Header("Main Game")]
    [Tooltip("Name of the scene you want to load when loading the main game.")]
    public string       MainGame;
    public GameObject   DeathScreen;        // Window that shows up when you die.
    public GameObject   QuitScreen;         // window that shows up when you press quit.

    [Header("Start Screen")]
    public GameObject   MainScreen;         // Screen with buttons to Play, Reset score and Quit.
    public GameObject   ResetScoreScreen;   // Screen to warn about resetting the highscore.

    [Header("Debug")]
    public bool     FreezeGame;                         // Freezes the game when pressed.


    private void Awake()
    {
        // Singleton
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }

        // Make sure there are no screens active.
        DeathScreen.SetActive(false);
        QuitScreen.SetActive(false);
        ResetScoreScreen.SetActive(false);
        MainScreen.SetActive(true);
    }

    private void Update()
    {
        // If the game is paused freeze everything. If the game is not, don't do so. 
        if (FreezeGame == true && Time.timeScale == 1)
        {
            Time.timeScale = 0;
        }
        else if (FreezeGame == false && Time.timeScale == 0)
        {
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// Loads and starts the main game. 
    /// </summary>
    public void LoadMainGame()
    {
        SceneManager.LoadScene(MainGame);
    }


    /// <summary>
    /// Opens a screen to ask wether to reset score or not.
    /// </summary>
    public void ResetScreen()
    {
        MainScreen.SetActive(false);
        ResetScoreScreen.SetActive(true);
    }

    /// <summary>
    /// Resets the highscore.
    /// </summary>
    public void ResetScore()
    {
        ScoreManager.Instance.WipeHighscore();
        ResetScoreScreen.SetActive(false);
        MainScreen.SetActive(true);
    }

    public void DontResetScore()
    {
        ResetScoreScreen.SetActive(false);
        MainScreen.SetActive(true);
    }


    /// <summary>
    /// Actions performed on death in Main game.
    /// </summary>
    public void Death()
    {   
        // Stop increasing the score. And save the highscore.
        ScoreManager.Instance.Counting = false;
        ScoreManager.Instance.SaveHighScore();
        
        DeathScreen.SetActive(true);
    }

    /// <summary>
    /// Enables a screen to ask if you want to quit.
    /// </summary>
    public void EndGame()
    {
        DeathScreen.SetActive(false);
        QuitScreen.SetActive(true);
    }

    /// <summary>
    /// Shuts off the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
