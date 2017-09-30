using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace BehavorTreeDesigner
{
	public class SetWaypoint : MonoBehaviour
	{
		public Transform waypointRoot;

		private BehaviorManager manager;

		private void Start()
		{
			manager = GetComponent<BehaviorManager>();
			manager.data.Add("_BTD_Waypoint", waypointRoot);
		}
	}
}
