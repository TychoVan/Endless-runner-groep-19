using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [Header("Debug")]
    public bool FreezeGame;
    public static GameManager Instance;

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
}
