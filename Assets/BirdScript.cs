using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	[SerializeField]
	private Rigidbody2D myRigidbody;
	public float flapStrength;

	public LogicScript logic;

	public bool isAlive = true;

	public event EventHandler OnPipeCollision;

	// Start is called before the first frame update
	void Start()
	{
		logic = LogicScript.Instance;
	}

	// Update is called once per frame
	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space) && isAlive)
		{
			myRigidbody.velocity = Vector2.up * flapStrength;
		}

	}

	private void OnCollisionEnter2D(Collision2D other)
	{
		OnPipeCollision?.Invoke(this, EventArgs.Empty);
		isAlive = false;
	}
}
