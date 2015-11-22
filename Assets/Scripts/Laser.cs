using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    public float m_speed = 30.0f;
    private float killDist = 100.0f;
    public int m_ownerId = 0;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position += transform.forward * m_speed * Time.deltaTime;


        if (transform.position.z > killDist)
        {
            Destroy(gameObject);
        }
	}


}
