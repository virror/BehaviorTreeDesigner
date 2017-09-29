using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Entries/TagToEntry")]
	public class TagToEntry : BaseBehaviorNode
	{
		[SerializeField]
		private string selectedTag = "";
		[SerializeField]
		private string entry = "";

		public override Node Create(Vector2 pos)
		{
			TagToEntry node = CreateInstance<TagToEntry>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Tag:");
			selectedTag = EditorGUILayout.TagField(selectedTag);
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
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

			agent = (Transform)data.Get("Agent");
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
			
			data.Add(entry, closest);
			return NodeStatus.SUCCESS;
		}
	}
}
