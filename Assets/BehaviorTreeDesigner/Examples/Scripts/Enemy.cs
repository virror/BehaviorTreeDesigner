using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehavorTreeDesigner.Example
{
	public class Enemy : MonoBehaviour
	{
		private int health = 3;
		private float spawnDelay = 0.1f;
		private float spawnDelayTimer = 0f;
		
		private void OnTriggerEnter(Collider collider)
		{
			if(collider.name == "Bullet(Clone)" && Time.time >= spawnDelayTimer)
			{
				health -= 1;
				if(health == 0)
				{
					Destroy(gameObject);
				}
				Destroy(collider.gameObject);
				spawnDelayTimer = Time.time + spawnDelay;
			}
		}
	}
}