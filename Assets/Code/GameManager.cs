using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager   Instance;

    [Tooltip("Name of the scene you want to load when loading the main game.")]
    public string   MainGame;

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
    }

    public void Start()
    {
        // Make sure there are no screens active.
        UIManager.Instance.DeathScreen.SetActive(false);
        UIManager.Instance.QuitScreen.SetActive(false);
        UIManager.Instance.ResetScoreScreen.SetActive(false);
        UIManager.Instance.MainScreen.SetActive(true);
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
        UIManager.Instance.MainScreen.SetActive(false);
        UIManager.Instance.ResetScoreScreen.SetActive(true);
    }

    /// <summary>
    /// Resets the highscore and returns to the original startscreen. When in StarScreen scene.
    /// </summary>
    public void ResetScore()
    {
        ScoreManager.Instance.WipeHighscore();
        UIManager.Instance.ResetScoreScreen.SetActive(false);
        UIManager.Instance.MainScreen.SetActive(true);
    }

    /// <summary>
    /// Returns to the original startscreen. When in StarScreen scene.
    /// </summary>
    public void DontResetScore()
    {
        UIManager.Instance.ResetScoreScreen.SetActive(false);
        UIManager.Instance.MainScreen.SetActive(true);
    }


    /// <summary>
    /// Actions performed on death in Main game.
    /// </summary>
    public void Death()
    {   
        // Stop increasing the score. And save the highscore.
        ScoreManager.Instance.Counting = false;
        ScoreManager.Instance.SaveHighScore();

        UIManager.Instance.DeathScreen.SetActive(true);
    }

    /// <summary>
    /// Enables a screen to ask if you want to quit.
    /// </summary>
    public void EndGame()
    {
        UIManager.Instance.DeathScreen.SetActive(false);
        UIManager.Instance.QuitScreen.SetActive(true);
    }

    /// <summary>
    /// Shuts off the game.
    /// </summary>
    public void QuitGame()
    {
        Application.Quit();
    }
}
