using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	public static UIManager		Instance;

	[Header("Main Game")]
	public TextMeshProUGUI		Score, HighScore;
	public TextMeshProUGUI		Health;

	public GameObject			DeathScreen;					// Window that shows up when you die.
	public TextMeshProUGUI		DeadScore, DeadHighScore;
	public GameObject			QuitScreen;						// window that shows up when you press quit.

	[Header("Start Screen")]
	public GameObject			MainScreen;						// Screen with buttons to Play, Reset score and Quit.
	public GameObject			ResetScoreScreen;				// Screen to warn about resetting the highscore.

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
}
