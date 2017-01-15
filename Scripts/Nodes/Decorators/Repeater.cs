using System.Collections;
using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Decorator/Repeater")]
	public class Repeater : BaseBehaviorNode 
	{
		[SerializeField]
		private int repNumber;

		public override Node Create(Vector2 pos)
		{
			Repeater node = CreateInstance<Repeater>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 100);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 50);

			return node;
		}

		protected internal override void NodeGUI()
		{
			base.NodeGUI();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Repeats: ");
			repNumber = EditorGUILayout.IntField(repNumber, GUILayout.Width(25));
			GUILayout.EndHorizontal();
		}

		public override void Init(Hashtable data)
		{
			
		}

		public override NodeStatus Tick()
		{
			if(this.Outputs[0].connections.Count == 0)
			{
				Debug.LogError("Behavor Tree Designer\nOutput node is not connected on node: " + this.name);
				return NodeStatus.ERROR;
			}

			BaseBehaviorNode node = (BaseBehaviorNode)this.Outputs[0].connections[0].body;
			NodeStatus status = NodeStatus.SUCCESS;
			
			for(int i = 0; i < repNumber; i++)
			{
				status = node.Tick();
				if(status == NodeStatus.FAILURE)
					return NodeStatus.FAILURE;
			}
			return status;
		}
	}
}