using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderHelper : MonoBehaviour
{
	public string allowedName;
	[HideInInspector]
	public Transform trigger;

	private void OnTriggerEnter(Collider other)
	{
		if(allowedName == other.name)
		{
			trigger = other.transform;
		}
	}

	private void OnTriggerExit(Collider other)
	{
		if(allowedName == other.name)
		{
			trigger = null;
		}
	}

	private void OnDestroy()
	{
		trigger = null;
	}
}
