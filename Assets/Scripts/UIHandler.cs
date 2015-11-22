using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIHandler : MonoBehaviour {
    public Text m_player0Text, m_player1Text;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_player0Text.text = "Player 1: " + ScoreManager.playerScore0;
        m_player1Text.text = "Player 2: " + ScoreManager.playerScore1;
	}
}
