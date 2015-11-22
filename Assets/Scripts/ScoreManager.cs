using UnityEngine;
using System.Collections;

public class ScoreManager : MonoBehaviour {

	public Transform player0;
	public Transform player1;
	public int outScore0;
	public int outScore1;

	public static int playerScore0 = 0;
	public static int playerScore1 = 0;

	private static PlayerScript script0;
	private static PlayerScript script1;

	// Use this for initialization
	void Start () {
		script0 = player0.GetComponent<PlayerScript>();
		script1 = player1.GetComponent<PlayerScript>();
	}
	
	// Update is called once per frame
	void Update () {
		outScore0 = playerScore0;
		outScore1 = playerScore1;
	}

	public static void addScore(PlayerScript player, int score)
	{
		if (player == script0)
			playerScore0 += score;
		else if(player == script1)
			playerScore1 += score;
	}
}
