using UnityEngine;
using System.Collections;

public class WinCondition : MonoBehaviour {

	public Transform player0;
	public Transform player1;
	private PlayerScript script0;
	private PlayerScript script1;

	// Use this for initialization
	void Start () {
		script0 = player0.GetComponent<PlayerScript>();
		script1 = player1.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		bool playing0 = script0.isLoggedIn() && script0.isAlive();
		bool playing1 = script1.isLoggedIn() && script1.isAlive();
		if (!(playing0 || playing1))
		{
			Application.LoadLevel("gameover");
		}
	}
}
