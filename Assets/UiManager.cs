using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{

	[SerializeField]
	private GameObject logicManager;

	private LogicScript logicManagerScript;

	[SerializeField]
	private Text playerScoreText;


	// Start is called before the first frame update
	void Start()
	{
		if (logicManager != null)
		{
			logicManagerScript = logicManager.GetComponent<LogicScript>();
			if (logicManagerScript != null)
			{
				logicManagerScript.OnUpdateScore += UpdateScoreHandler;
			}
		}
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void UpdateScoreHandler(object sender, LogicScript.OnUpdateScoreEventArgs args)
	{
		playerScoreText.text = args.score.ToString();
	}


	private void OnDestroy()
	{
		logicManagerScript.OnUpdateScore -= UpdateScoreHandler;
	}
}
