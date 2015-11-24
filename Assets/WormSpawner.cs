using UnityEngine;
using System.Collections;

public class WormSpawner : MonoBehaviour {

	public Transform[]  spawnList;
	public float spawnInterval = 15.0f;
	public float bodyPartsInterval = 0.5f;
	public int numBodyParts = 10;

	private float bodyPartTimer = 0.0f;
	private float totalTimer = 0.0f;
	private int index = 0;
	bool spawning = false;

	void Start () {
	
	}
	
	void Update () {
		totalTimer += Time.deltaTime;
		if (totalTimer >= spawnInterval)
		{
			spawning = true;
			totalTimer = 0.0f;
		}

		if(spawning)
		{
			bodyPartTimer += Time.deltaTime;
			if(bodyPartTimer >= bodyPartsInterval)
			{
				bodyPartTimer = 0.0f;
				if(index == 0)
				{
					GameObject.Instantiate(spawnList[0], transform.position, Quaternion.identity);
					index++;
				}
				else if(index < numBodyParts)
				{
					GameObject.Instantiate(spawnList[1], transform.position, Quaternion.identity);
					index++;
				}
				else
				{
					index = 0;
					spawning = false;
				}
			}
		}
	}
}
