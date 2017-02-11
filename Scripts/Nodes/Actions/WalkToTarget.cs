using UnityEngine;
using UnityEditor;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/WalkToTarget")]
	public class WalkToTarget : BaseBehaviorNode
	{
		[SerializeField]
		private string entry = "";
		[SerializeField]
		private float stopDist = 0;

		public override Node Create(Vector2 pos)
		{
			WalkToTarget node = CreateInstance<WalkToTarget>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
			GUILayout.Label("Stop distance:");
			stopDist = EditorGUILayout.FloatField(stopDist, GUILayout.Width(40));
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform player = (Transform)data.Get("Agent");
			Vector3 target = ((Transform)data.Get(entry)).position;
			NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
			Vector3 playerPos = player.position;

			if(agent == null)
			{
				Debug.LogError("Behavor Tree Designer\nNo NavMeshAgent component found on node: " + this.name);
				return NodeStatus.ERROR;
			}

			agent.stoppingDistance = stopDist;
			target.y = 0;
			playerPos.y = 0;
			agent.destination = target;
			if(Vector3.Distance(target, playerPos) < stopDist)
			{
				return NodeStatus.SUCCESS;
			}
			else if(agent.hasPath)
			{
				return NodeStatus.RUNNING;
			}
			else
			{
				return NodeStatus.FAILURE;
			}
		}
	}
}
