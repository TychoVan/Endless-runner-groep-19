using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public SaveGameData     Data;
    public float            score;

    private void Start()
    {
        StartCoroutine(Counter());
        // Update the score on the UI.
        UIManager.Instance.HighScore.text = string.Format("Highscore: {0}", Data.HighScore);
    }

    public void Update()
    {
        if (score > Data.HighScore)
        {
            Data.HighScore = score;
            // Update the score on the UI.
            UIManager.Instance.HighScore.text = string.Format("Highscore: {0}", Data.HighScore);
        }
    }


    /// <summary>
    /// Add an amount to the pre-existing score.
    /// </summary>
    /// <param name="amount">How much you want to add to the score.</param>
    public void AddToScore(float amount)
    {
        score += amount;
    }


    /// <summary>
    /// Resets the highscore back to 0.
    /// </summary>
    public void WipeHighscore()
    {
        Data.HighScore = 0;
    }


    /// <summary>
    /// As long as the game is running ad 0.1 points to the counter every tenth of a second.
    /// </summary>
    /// <returns></returns>
    private IEnumerator Counter()
    {
        while (true)
        {
            while(Time.timeScale == 1)
            {
                yield return new WaitForSeconds(0.1f);
                score += 0.1f;
                score = Mathf.Round(score * 10.0f) * 0.1f;
                // Update the score on the UI.
                UIManager.Instance.Score.text = string.Format("Score: {0}", score);
            }
        }
    }
}
