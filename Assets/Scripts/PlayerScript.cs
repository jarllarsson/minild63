using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int m_playerNumber = 0;
    public float m_speed = 50.0f;
    private bool m_loggedIn = true;

    private Renderer m_renderer;

	// Use this for initialization
	void Awake ()
    {
        m_renderer = transform.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        Vector2 inputMovement = new Vector2(Input.GetAxis("Horizontal" + m_playerNumber), Input.GetAxis("Vertical" + m_playerNumber));
        transform.localPosition += new Vector3(inputMovement.x, inputMovement.y, 0.0f) * Time.deltaTime * m_speed;
	}

    public void Logout()
    {
        if (m_renderer)
        {
            m_renderer.enabled = false;
            m_loggedIn = false;
        }
    }

    public void Login()
    {
        if (m_renderer)
        {
            m_renderer.enabled = true;
            m_loggedIn = true;
        }
    }

    public bool isLoggedIn()
    {
        return m_loggedIn;
    }
}
