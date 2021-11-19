using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	public static UIManager		Instance;
	public TextMeshProUGUI		Score, HighScore;
	public TextMeshProUGUI		Health;

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
