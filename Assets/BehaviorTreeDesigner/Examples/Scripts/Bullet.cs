using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehavorTreeDesigner.Example
{
	public class Bullet : MonoBehaviour
	{
		private void Start ()
		{
			Destroy(gameObject, 2);
		}

		private void Update()
		{
			transform.Translate(Vector3.forward * 10 * Time.deltaTime, Space.Self);
		}
	}
}