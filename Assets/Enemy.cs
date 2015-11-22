using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public enum MovementPattern {
		Straight
	}
	public enum KillReason {
		HitWall,
		Player
	}

	public float movementSpeed = 1.0f;
	public MovementPattern movementPattern;

	private readonly float zDeathLimit = -15.0f;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (movementPattern == MovementPattern.Straight)
		{
			transform.position = transform.position + new Vector3(0, 0, -movementSpeed * Time.deltaTime);
		}

		if (transform.position.z <= zDeathLimit)
		{
			Kill(KillReason.HitWall, 0);
		}
	}

	public void Kill(KillReason reason, int value)
	{
		Destroy(gameObject);
	}
}
