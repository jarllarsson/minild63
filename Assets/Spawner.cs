﻿using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour {

	public Transform[]  spawnList;
	public float spawnInterval = 1.0f;
	public float width = 20.0f;
	public float height = 10.0f;

	private float timer = 0.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		if (timer >= spawnInterval)
		{
			timer = 0.0f;
			GameObject.Instantiate(spawnList[Random.Range(0, spawnList.Length)], transform.position + RandomPlane(width, height), Quaternion.identity);
		}
	}

	Vector3 RandomPlane(float width, float height)
	{
		return new Vector3((Random.value - 0.5f) * width, Random.value * height, 0.0f);
	}
}
