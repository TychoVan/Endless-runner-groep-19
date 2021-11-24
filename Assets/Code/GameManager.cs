using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager   Instance;

    [Header("Debug")]
    public bool     FreezeGame;

    [Header("Placeholder")]
    [Tooltip("Name of the scene you want to load when loading the main game.")]
    public string       MainGame;
    public GameObject   DeathScreen, QuitScreen;

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

    public void Death()
    {
        ScoreManager.Instance.SaveHighScore();
        Time.timeScale = 0;
        FreezeGame = true;
        DeathScreen.SetActive(true);
    }

    public void EndGame()
    {
        DeathScreen.SetActive(false);
        QuitScreen.SetActive(true);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
