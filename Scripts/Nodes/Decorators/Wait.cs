using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Decorator/Wait")]
	public class Wait : BaseBehaviorNode 
	{
		[SerializeField]
		private float waitTime;
		private bool start = true;

		public override Node Create(Vector2 pos)
		{
			Wait node = CreateInstance<Wait>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Wait time(s): ");
			waitTime = EditorGUILayout.FloatField(waitTime, GUILayout.Width(50));
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			data.Add(guid.ToString(), 0.0f);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			if(this.Outputs[0].connections.Count == 0)
			{
				Debug.LogError("Behavor Tree Designer\nOutput node is not connected on node: " + this.name);
				return NodeStatus.ERROR;
			}

			BaseBehaviorNode node = (BaseBehaviorNode)this.Outputs[0].connections[0].body;
			
			if(start)
			{
				data.Add(guid.ToString(), Time.time);
			}

			float time = (float)data.Get(guid.ToString());

			if(time + waitTime > Time.time)
			{
				start = false;
				return NodeStatus.RUNNING;
			}
			else
			{
				start = true;
				return node.Tick(data);	
			}
		}
	}
}