using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Debug/ReadEntry")]
	public class ReadEntry : BaseBehaviorNode 
	{
		[SerializeField]
		private string entry = "";
		[SerializeField]
		private bool global = false;

		public override Node Create(Vector2 pos)
		{
			ReadEntry node = CreateInstance<ReadEntry>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
			GUILayout.Label("Global:");
			global = EditorGUILayout.Toggle(global);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			object classObj;
			if(global)
			{
				classObj = data.GetGlobal(entry);
			}
			else
			{
				classObj = data.Get(entry);
			}
			if(classObj == null)
				classObj = "null";
			Debug.Log("Behavor Tree Designer Logger\nEntry: " + classObj);
			return NodeStatus.SUCCESS;
		}
	}
}