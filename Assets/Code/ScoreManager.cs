using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public float                Score;          // Current score of the player.
    public float                HighScore;      // Highest score the player has gotten.
    public bool                 Counting;       // As long as this is true the score will increase.

    public static ScoreManager  Instance;

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

    private void Start()
    {
        Counting = true;
        StartCoroutine(Counter());
        HighScore = PlayerPrefs.GetFloat("HighScore", 0);

        // Update the score on the UI.
        UIManager.Instance.HighScore.text = string.Format("Highscore: {0}", HighScore);
    }

    public void Update()
    {
        if (Score > HighScore)
        {
            HighScore = Score;
            // Update the score on the UI.
            UIManager.Instance.HighScore.text = string.Format("Highscore: {0}", HighScore);
        }
    }


    /// <summary>
    /// Add an amount to the pre-existing score.
    /// </summary>
    /// <param name="amount">How much you want to add to the score.</param>
    public void AddToScore(float amount)
    {
        Score += amount;
    }

    /// <summary>
    /// Saves the highscore to playerprefs.
    /// </summary>
    public void SaveHighScore()
    {
        PlayerPrefs.SetFloat("HighScore", Score);
    }

    /// <summary>
    /// Resets the highscore back to 0.
    /// </summary>
    public void WipeHighscore()
    {
        PlayerPrefs.DeleteKey("HighScore");
        HighScore = 0;
        UIManager.Instance.HighScore.text = string.Format("Highscore: {0}", HighScore);
    }


    /// <summary>
    /// As long as the game is running ad 0.1 points to the counter every tenth of a second.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Counter() 
    {
        while (Counting)
        {
            yield return new WaitForSeconds(0.1f);
            Score += 10f;
            // Update the score on the UI.
            UIManager.Instance.Score.text = string.Format("Score: {0}", Score);
        }
    }
}
