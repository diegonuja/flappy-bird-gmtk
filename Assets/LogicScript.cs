using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class LogicScript : MonoBehaviour
{
	public static LogicScript Instance { get; private set; }

	[SerializeField]
	private GameObject bird;
	private BirdScript birdScript;

	public int playerScore = 0;

	public Text playerScoreText;

	public GameObject gameOverScreen;

	private void Start()
	{
		if (bird != null)
		{
			birdScript = bird.GetComponent<BirdScript>();
			if (birdScript != null)
			{
				birdScript.OnPipeCollision += BirdCollisionHandler;
			}
		}
	}

	private void BirdCollisionHandler(object sender, EventArgs e)
	{
		GameOver();
	}

	private void Awake()
	{
		// If there is an instance, and it's not me, delete myself.
		if (Instance != null && Instance != this)
		{
			Destroy(this);
		}
		else
		{
			Instance = this;
		}
	}

	[ContextMenu("Increase score")]
	public void AddScore(int toAdd)
	{
		playerScore += toAdd;
		playerScoreText.text = playerScore.ToString();
	}

	public void RestartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void GameOver()
	{
		gameOverScreen.SetActive(true);
	}
}
