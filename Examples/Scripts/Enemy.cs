using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehavorTreeDesigner.Example
{
	public class Enemy : MonoBehaviour
	{
		private int health = 3;
		
		private void OnTriggerEnter(Collider collider)
		{
			if(collider.name == "Bullet(Clone)")
			{
				health -= 1;
				if(health == 0)
				{
					Destroy(gameObject);
				}
				Destroy(collider.gameObject);
			}
		}
	}
}