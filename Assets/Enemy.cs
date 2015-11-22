using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	
	public enum MovementPattern {
		Straight
	}
	public enum KillReason {
		HitWall,
		Player
	}

	public float movementSpeed = 1.0f;
	public MovementPattern movementPattern;
	public float radius = 0.5f;
	public int damageToPlayer = 1;

	private readonly float zDeathLimit = -15.0f;

	private PlayerScript[] playerReferences;

	// Use this for initialization
	void Start () {
		playerReferences = new PlayerScript[2];
		int index = 0;
		foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Player"))
		{
			if (index > 1)
				break;
			playerReferences[index] = obj.GetComponent<PlayerScript>();
			index++;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (movementPattern == MovementPattern.Straight)
		{
			transform.position = transform.position + new Vector3(0, 0, -movementSpeed * Time.deltaTime);
		}

		if (transform.position.z <= zDeathLimit)
		{
			Kill(KillReason.HitWall, 0);
		}
		
		handlePlayerCollision(playerReferences[0], radius);
		handlePlayerCollision(playerReferences[1], radius);
	}
	
	private void handlePlayerCollision(PlayerScript player, float radius)
	{
		float squaredRadius = (player.m_radius + radius) * (player.m_radius + radius);
		float squaredDistance = (player.transform.position - transform.position).sqrMagnitude;
		if (squaredDistance < squaredRadius)
		{
			player.Damage(damageToPlayer);
			Kill (KillReason.Player, 0);
		}
	}

	private void Kill(KillReason reason, int value)
	{
		Destroy(gameObject);
	}
}
