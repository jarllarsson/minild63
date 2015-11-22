using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int m_playerNumber = 0;
    public float m_speed = 50.0f;
    private bool m_loggedIn = true;

    private Renderer m_renderer;
	
	private enum PlayerState {
		Normal,
		Damaged
	}
	public float m_radius = 0.5f;
	public float m_blinkTime = 1.5f;
	public int m_health = 10;
	private float m_blinkTimer = 0;
	private PlayerState m_playerState;

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
		
		if (m_playerState == PlayerState.Damaged)
		{
			m_blinkTimer += Time.deltaTime;
			if (m_blinkTimer >= m_blinkTime)
			{
				m_playerState = PlayerState.Normal;
			}
		}
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

	public void Damage(int value)
	{
		if (m_playerState == PlayerState.Damaged)
		{
			m_health -= value;
		}
		m_playerState = PlayerState.Damaged;
	}
}
