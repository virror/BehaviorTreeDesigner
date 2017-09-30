using UnityEditor;
using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/GetNextWaypoint")]
	public class GetNextWaypoint : BaseBehaviorNode
	{
		[SerializeField]
		private string entry = "";
		[SerializeField]
		private string waypoint = "";
		private Transform waypointParent;
		private bool backwards = false;

		public override Node Create(Vector2 pos)
		{
			GetNextWaypoint node = CreateInstance<GetNextWaypoint>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 60);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
			GUILayout.Label("Waypoint:");
			waypoint = EditorGUILayout.TextField(waypoint);
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			data.Add("_BTD_WaypointIndex", -1);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			int index = (int)data.Get("_BTD_WaypointIndex");
			waypointParent = (Transform)data.Get("_BTD_Waypoint");

			if(waypointParent == null)
			{
				return NodeStatus.FAILURE;
			}
			Waypoints waypoints = waypointParent.GetComponent<Waypoints>();

			if(!waypoints.circular && index == waypointParent.childCount - 1)
			{
				backwards = true;
			}
			if(!waypoints.circular && index == 0)
			{
				backwards = false;
			}

			if(backwards)
			{
				index--;
			}
			else
			{
				index++;
			}

			if(index >= waypointParent.childCount)
			{
				index = 0;
			}
			if(index < 0)
			{
				index = waypointParent.childCount - 1;
			}
			
			Transform target = waypointParent.GetChild(index);
			data.Add(entry, target);
			data.Add("_BTD_WaypointIndex", index);

			if(target == null)
			{
				return NodeStatus.FAILURE;
			}

			return NodeStatus.SUCCESS;
		}
	}
}
