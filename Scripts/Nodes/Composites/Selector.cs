using UnityEngine;
using NodeEditorFramework;
using System.Collections;
using System.Collections.Generic;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Composite/Selector")]
	public class Selector : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			Selector node = CreateInstance<Selector>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 140, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 70);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 20);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 70);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 120);
			
			return node;
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			List<NodeOutput> nodes = this.Outputs;

			foreach(NodeOutput node in nodes)
			{
				if(node.connections.Count == 0)
					continue;
					
				NodeStatus childstatus = ((BaseBehaviorNode)(node.connections[0].body)).Tick(data);
				if(childstatus != NodeStatus.FAILURE)
				{
					return childstatus;
				}
			}
			return NodeStatus.FAILURE;
		}
	}
}