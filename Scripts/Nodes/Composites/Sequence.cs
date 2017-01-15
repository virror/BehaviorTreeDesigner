using UnityEngine;
using NodeEditorFramework;
using System.Collections;
using System.Collections.Generic;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Composite/Sequence")]
	public class Sequence : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			Sequence node = CreateInstance<Sequence>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 140, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 70);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 20);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 70);
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 120);

			return node;
		}

		public override void Init(Hashtable data)
		{

		}

		public override NodeStatus Tick()
		{
			List<NodeOutput> nodes = this.Outputs;

			foreach(NodeOutput node in nodes)
			{
				if(node.connections.Count == 0)
					continue;
					
				NodeStatus childstatus = ((BaseBehaviorNode)(node.connections[0].body)).Tick();
				if(childstatus != NodeStatus.SUCCESS)
				{
					return childstatus;
				}
			}
			return NodeStatus.SUCCESS;
		}
	}
}