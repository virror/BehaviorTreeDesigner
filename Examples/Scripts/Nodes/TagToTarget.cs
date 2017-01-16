using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/TagToTarget")]
	public class TagToTarget : BaseBehaviorNode
	{
		[SerializeField]
		private string selectedTag = "";

		public override Node Create(Vector2 pos)
		{
			TagToTarget node = CreateInstance<TagToTarget>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Tag:");
			selectedTag = EditorGUILayout.TagField(selectedTag);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			GameObject[] objects = GameObject.FindGameObjectsWithTag(selectedTag);
			Transform agent;
			Transform closest;
			float minDist;

			if(objects.Length == 0)
			{
				return NodeStatus.FAILURE;
			}

			agent = data.Get<Transform>("Agent");
			minDist = Vector3.Distance(agent.position, objects[0].transform.position);
			closest = objects[0].transform;

			for(int i = 1; i < objects.Length; i++)
			{
				float distance = Vector3.Distance(agent.position, objects[i].transform.position);
				if(distance < minDist)
				{
					minDist = distance;
					closest = objects[i].transform;
				}
			}

			data.Add<Transform>("Target", closest);
			return NodeStatus.SUCCESS;
		}
	}
}
