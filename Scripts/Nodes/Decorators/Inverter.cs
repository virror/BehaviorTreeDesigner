using System.Collections;
using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Decorator/Inverter")]
	public class Inverter : BaseBehaviorNode 
	{
		public override Node Create(Vector2 pos)
		{
			Inverter node = CreateInstance<Inverter>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 50);
			
			return node;
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			if(this.Outputs[0].connections.Count == 0)
			{
				Debug.LogError("Behavor Tree Designer\nOutput node is not connected on node: " + this.name);
				return NodeStatus.ERROR;
			}
			
			BaseBehaviorNode node = (BaseBehaviorNode)this.Outputs[0].connections[0].body;
			NodeStatus status = node.Tick(data);

			if(status == NodeStatus.SUCCESS)
			{
				status = NodeStatus.FAILURE;
			}
			else if(status == NodeStatus.FAILURE)
			{
				status = NodeStatus.SUCCESS;
			}
			return status;
		}
	}
}