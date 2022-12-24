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

	public GameObject gameOverScreen;

	// Event used to updated the UI
	public event EventHandler<OnUpdateScoreEventArgs> OnUpdateScore;
	public class OnUpdateScoreEventArgs : EventArgs
	{
		public int score;
	}

	private void Start()
	{
		if (bird != null)
		{
			birdScript = bird.GetComponent<BirdScript>();
			if (birdScript != null)
			{
				birdScript.OnPipeCollision += BirdCollisionHandler;
				birdScript.OnPipeMiddleTrigger += OnPipeMiddleHandler;
			}
		}
	}

	private void OnDestroy()
	{
		birdScript.OnPipeCollision -= BirdCollisionHandler;
		birdScript.OnPipeMiddleTrigger -= OnPipeMiddleHandler;
	}

	private void OnPipeMiddleHandler(object sender, EventArgs e)
	{
		AddScore(1);
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
	private void AddScore(int toAdd)
	{
		playerScore += toAdd;
		OnUpdateScore?.Invoke(this, new OnUpdateScoreEventArgs { score = playerScore });
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
