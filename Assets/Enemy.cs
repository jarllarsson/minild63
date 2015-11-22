using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public enum MovementPattern {
		Straight
	}

	public float movementSpeed = 1.0f;
	public MovementPattern movementPattern;

	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (movementPattern == MovementPattern.Straight)
		{
			transform.position = transform.position + new Vector3(0, 0, -movementSpeed * Time.deltaTime);
		}
	}
}
