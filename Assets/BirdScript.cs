using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour
{
	private const int PIPE_LAYER = 6;

	[SerializeField]
	private Rigidbody2D myRigidbody;
	public float flapStrength;

	public bool isAlive = true;

	public event EventHandler OnPipeCollision;

	public event EventHandler OnPipeMiddleTrigger;

	// Start is called before the first frame update
	void Start()
	{
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
		if (other.gameObject.layer == PIPE_LAYER)
		{
			OnPipeCollision?.Invoke(this, EventArgs.Empty);
			isAlive = false;
		}
	}

	private void OnTriggerEnter2D(Collider2D other)
	{
		if (isAlive) OnPipeMiddleTrigger?.Invoke(this, EventArgs.Empty);
	}
}
