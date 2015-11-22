using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int m_playerNumber = 0;

	// Use this for initialization
	void Start ()
    {
	
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 inputMovement = new Vector2(Input.GetAxis("Horizontal" + m_playerNumber), Input.GetAxis("Vertical" + m_playerNumber));
        transform.localPosition += new Vector3(inputMovement.x, inputMovement.y, 0.0f) * Time.deltaTime;
	}
}
