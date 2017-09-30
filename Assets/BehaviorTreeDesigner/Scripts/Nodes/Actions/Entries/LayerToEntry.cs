using UnityEngine;
using UnityEditor;
using System.Collections.Generic;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Entries/LayerToEntry")]
	public class LayerToEntry : BaseBehaviorNode
	{
		[SerializeField]
		private int selectedLayer;
		[SerializeField]
		private string entry = "";

		public override Node Create(Vector2 pos)
		{
			LayerToEntry node = CreateInstance<LayerToEntry>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 60);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Layer:");
			selectedLayer = EditorGUILayout.LayerField(selectedLayer);
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			GameObject[] objects = (GameObject[])GameObject.FindObjectsOfType(typeof(GameObject));
			Transform agent;
			Transform closest;
			float minDist;

			if(objects.Length == 0)
			{
				return NodeStatus.FAILURE;
			}

			List<GameObject> layerList = new List<GameObject>();
			for (int i = 0; i < objects.Length; i++)
			{
				if (objects[i].layer == selectedLayer)
				{
					layerList.Add(objects[i]);
				}
			}

			agent = (Transform)data.Get("_BTD_Agent");
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
