using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
	public static UIManager		Instance;
	public TextMeshProUGUI		Score, HighScore;

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
