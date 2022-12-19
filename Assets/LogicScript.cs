using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogicScript : MonoBehaviour
{
	public int playerScore = 0;

	public Text playerScoreText;


	[ContextMenu("Increase score")]
	public void addScore(int toAdd)
	{
		playerScore += toAdd;
		playerScoreText.text = playerScore.ToString();
	}


}
