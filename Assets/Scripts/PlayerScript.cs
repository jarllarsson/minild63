using UnityEngine;
using System.Collections;

public class PlayerScript : MonoBehaviour
{
    public int m_playerNumber = 0;
    public float m_speed = 50.0f;
    private bool m_loggedIn = true;

    private Renderer m_renderer;

    public Transform m_bulletPrefab;
    public float m_fireCooldownTime = 0.3f;
    public float m_fireCooldownTimer = 0.0f;

    public AudioSource sndSource;
    public AudioClip bulletSound;

    public int m_score = 0;

	// Use this for initialization
	void Awake ()
    {
        m_renderer = transform.GetComponent<Renderer>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (isLoggedIn())
        {
            Vector2 inputMovement = new Vector2(Input.GetAxis("Horizontal" + m_playerNumber), Input.GetAxis("Vertical" + m_playerNumber));
            transform.localPosition += new Vector3(inputMovement.x, inputMovement.y, 0.0f) * Time.deltaTime * m_speed;

            if (m_fireCooldownTimer <= 0.0f)
            {
                if (Input.GetAxis("Fire" + m_playerNumber) > 0.0f)
                {
                    m_fireCooldownTimer = m_fireCooldownTime;
                    Fire();
                }
            }
            m_fireCooldownTimer -= Time.deltaTime;
        }
	}

    private void Fire()
    {
        Transform obj = Instantiate(m_bulletPrefab, transform.position, Quaternion.identity) as Transform;
        if (obj)
        {
            Laser laserObj = obj.GetComponent<Laser>();
            if (laserObj)
                laserObj.m_owner = this;
        }
        sndSource.PlayOneShot(bulletSound);
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

    public void Score(int p_score)
    {
        m_score += p_score;
    }
}
