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

		protected override void NodeGUI()
		{
			base.NodeGUI();
			GUILayout.BeginHorizontal();
			GUILayout.Label("Repeats: ");
			repNumber = EditorGUILayout.IntField(repNumber, GUILayout.Width(25));
			GUILayout.EndHorizontal();
		}

		public override void Init(BehaviorBlackboard data)
		{
			data.Add(guid.ToString(), 0);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			if(this.Outputs[0].connections.Count == 0)
			{
				Debug.LogError("Behavor Tree Designer\nOutput node is not connected on node: " + this.name);
				return NodeStatus.ERROR;
			}

			BaseBehaviorNode node = (BaseBehaviorNode)this.Outputs[0].connections[0].body;
			NodeStatus status = NodeStatus.SUCCESS;
			int rep = data.Get(guid.ToString());
			
			status = node.Tick(data);

			if(status == NodeStatus.RUNNING)
			{
				return status;
			}

			rep += 1;
			
			if(rep < repNumber)
			{
				status = NodeStatus.RUNNING;
				data.Add(guid.ToString(), rep);
			}
			else
			{
				data.Add(guid.ToString(), 0);
			}

			return status;
		}
	}
}