using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawnerScript : MonoBehaviour
{
	// Amount of seconds between the spawn of 2 pipes
	public float spawnerRate = 2;

	public float heightOffest = 10;
	private float timer = 0;

	public GameObject pipe;
	// Start is called before the first frame update
	void Start()
	{
		spawnPipe();
	}

	// Update is called once per frame
	void Update()
	{
		if (timer >= spawnerRate)
		{
			spawnPipe();
			timer = 0;
		}
		else
		{
			timer += Time.deltaTime;
		}
	}

	private void spawnPipe()
	{
		float highestPoint = transform.position.y + heightOffest;
		float lowestPoint = transform.position.y - heightOffest;

		Instantiate(pipe, new Vector3(transform.position.x, Random.Range(lowestPoint, highestPoint), 0), transform.rotation);
	}
}
