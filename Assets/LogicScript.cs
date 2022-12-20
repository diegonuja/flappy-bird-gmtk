using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LogicScript : MonoBehaviour
{
	public static LogicScript Instance { get; private set; }


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

	public int playerScore = 0;

	public Text playerScoreText;

	public GameObject gameOverScreen;

	private void Start()
	{

	}

	[ContextMenu("Increase score")]
	public void addScore(int toAdd)
	{
		playerScore += toAdd;
		playerScoreText.text = playerScore.ToString();
	}

	public void restartGame()
	{
		SceneManager.LoadScene(SceneManager.GetActiveScene().name);
	}

	public void gameOver()
	{
		gameOverScreen.SetActive(true);
	}


}
