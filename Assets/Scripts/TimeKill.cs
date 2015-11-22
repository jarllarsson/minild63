using UnityEngine;
using System.Collections;

public class TimeKill : MonoBehaviour {
    public float m_time = 1.0f;
    private float m_timer = 0.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        m_timer += Time.deltaTime;
        if (m_timer > m_time)
            Destroy(gameObject);
	}
}
