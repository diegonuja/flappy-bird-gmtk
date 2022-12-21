using System;
using UnityEngine;

public class PipeMiddleScript : MonoBehaviour
{

	public LogicScript logic;
	// Start is called before the first frame update

	void Start()
	{
		logic = LogicScript.Instance;
	}

	// Update is called once per frame
	void Update()
	{

	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.layer == 3)
		{
			logic.AddScore(1);
		}
	}
}
