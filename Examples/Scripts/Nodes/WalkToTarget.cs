using UnityEngine;
using UnityEditor;
using UnityEngine.AI;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/WalkToTarget")]
	public class WalkToTarget : BaseBehaviorNode
	{
		[SerializeField]
		private int stopDist = 0;

		public override Node Create(Vector2 pos)
		{
			WalkToTarget node = CreateInstance<WalkToTarget>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Stop distance:");
			stopDist = EditorGUILayout.IntField(stopDist, GUILayout.Width(40));
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform player = GameObject.FindGameObjectWithTag("Player").transform;
			Vector3 enemy = data.Get<Transform>("Target").position;
			NavMeshAgent agent = player.GetComponent<NavMeshAgent>();
			Vector3 playerPos = player.position;
			agent.stoppingDistance = stopDist;
			enemy.y = 0;
			playerPos.y = 0;
			agent.destination = enemy;
			if(Vector3.Distance(enemy, playerPos) < stopDist)
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
