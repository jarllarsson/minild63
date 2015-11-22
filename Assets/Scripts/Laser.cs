using UnityEngine;
using System.Collections;

public class Laser : MonoBehaviour {
    public float m_speed = 30.0f;
    private float m_killDist = 100.0f;
    public int m_damageValue = 1;
    public PlayerScript m_owner;
    public float m_radius;
    public Transform m_hitEffect;

    private static bool s_dirtyEnemyList = true;
    private static GameObject[] s_enemies;

	// Use this for initialization
	void Start () 
    {

	}
	
	// Update is called once per frame
	void Update () 
    {
        transform.position += transform.forward * m_speed * Time.deltaTime;


        if (transform.position.z > m_killDist)
        {
            Destroy(gameObject);
        }

        // only update list once per frame
        if (s_dirtyEnemyList)
        {
            updateEnemyList();
            s_dirtyEnemyList = false;
        }

        checkCollisionWithEnemy();
	}

    void LateUpdate()
    {
        s_dirtyEnemyList = true;
    }

    static void updateEnemyList()
    {
        s_enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    void checkCollisionWithEnemy()
    {
        foreach (GameObject enemy in s_enemies)
        {
            Enemy enemyScript = enemy.GetComponent<Enemy>();
            if (enemyScript)
            {
                float enemRadius = 1.0f;
                if (Vector3.SqrMagnitude(transform.position-enemy.transform.position) < (m_radius+enemRadius)*(m_radius+enemRadius))
                {
                    if (m_owner) m_owner.Score(enemyScript.killScore);
                    Instantiate(m_hitEffect, transform.position, Quaternion.identity);
                    Destroy(gameObject);
                    enemyScript.Kill(Enemy.KillReason.Player, m_damageValue);
                }
            }
        }
    }
}
