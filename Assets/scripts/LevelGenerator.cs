using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour 
{
	public float levelHeight = 5;
	public float scrollSpeed = 1;
	public float spawnGap = 1;
	public GameObject[] leftPrefabs;
	public GameObject[] middlePrefabs;
	public GameObject[] rightPrefabs;
	public GameManager game;

	private float distanceSinceLastSpawn;
	private List<GameObject> levelElements = new List<GameObject>();

	// Use this for initialization
	void Start () 
	{
		distanceSinceLastSpawn = spawnGap;
	}
	
	// Update is called once per frame
	void Update () 
	{
		moveElements (Time.deltaTime);
		while (distanceSinceLastSpawn > spawnGap)
		{
			spawnPrefab (distanceSinceLastSpawn - spawnGap);
			distanceSinceLastSpawn -= spawnGap;
		}
		destroyElements ();
	}

	void spawnPrefab (float offset)
	{
		int rand = Random.Range (0, 3);//< just for testing
		// select prefab based on audio data
		GameObject prefab = null;
		switch (rand)
		{
		case 0:
			prefab = leftPrefabs[Random.Range(0, leftPrefabs.Length)];
			break;
		case 1:
			prefab = middlePrefabs[Random.Range(0, middlePrefabs.Length)];
			break;
		case 2:
			prefab = rightPrefabs[Random.Range(0, rightPrefabs.Length)];
			break;
		}
		GameObject spawnedPrefab = (GameObject) Instantiate (prefab, transform.position, Quaternion.identity);
		// set to lower level border
		spawnedPrefab.transform.position += Vector3.down * (levelHeight / 2);
		// add offset (to counteract derivations caused by spawning "too late")
		spawnedPrefab.transform.position += Vector3.up * offset;
		// add to container so it will be moved
		levelElements.Add (spawnedPrefab);
	}

	void moveElements (float deltatime)
	{
		float distance = scrollSpeed * deltatime;
		foreach (GameObject element in levelElements)
		{
			element.transform.position += Vector3.up * distance;
		}
		distanceSinceLastSpawn += distance;
		// test
		game.score += distance;
	}

	void destroyElements ()
	{
		int s = 0;	//< security
		while (levelElements.Count > 0 && s<1000)
		{
			s++;
			if (levelElements[0].transform.position.y > levelHeight/2)
			{
				Destroy (levelElements[0]);
				levelElements.RemoveAt(0);
			}
			else return;
		}
	}
}
