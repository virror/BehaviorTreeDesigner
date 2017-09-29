using UnityEngine;
using UnityEditor;
#if UNITY_5_5_OR_NEWER
using UnityEngine.AI;
#endif
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/MoveToTarget")]
	public class MoveToTarget : BaseBehaviorNode
	{
		[SerializeField]
		private string entry = "";
		[SerializeField]
		private float stopDist = 0;

		public override Node Create(Vector2 pos)
		{
			MoveToTarget node = CreateInstance<MoveToTarget>();
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
			Transform target = ((Transform)data.Get(entry));
			NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
			Vector3 playerPos = player.position;

			if(agent == null)
			{
				Debug.LogError("Behavor Tree Designer\nNo NavMeshAgent component found on node: " + this.name);
				return NodeStatus.ERROR;
			}

			if(target == null)
			{
				return NodeStatus.ERROR;
			}

			Vector3 targetPos = target.position;
			agent.stoppingDistance = stopDist;
			targetPos.y = 0;
			playerPos.y = 0;
			agent.destination = targetPos;
			if(Vector3.Distance(targetPos, playerPos) < stopDist)
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
