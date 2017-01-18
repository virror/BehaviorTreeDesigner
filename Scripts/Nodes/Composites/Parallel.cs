using UnityEngine;
using NodeEditorFramework;
using System.Collections;
using System.Collections.Generic;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Composite/Parallel")]
	public class Parallel : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			Parallel node = CreateInstance<Parallel>();
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
			NodeStatus[] childstatus = new NodeStatus[nodes.Count];
			int count = 0;
			bool running = false;
			bool fail = false;

			for(int i = 0; i < nodes.Count; i++)
			{
				if(nodes[i].connections.Count == 0)
					continue;

				count ++;
				childstatus[i] = ((BaseBehaviorNode)(nodes[i].connections[0].body)).Tick(data);
			}

			if(count == 0)
			{
				return NodeStatus.ERROR;
			}

			foreach(NodeStatus status in childstatus)
			{
				if(status == NodeStatus.ERROR)
					return NodeStatus.ERROR;
				if(status == NodeStatus.RUNNING)
					running = true;
				if(status == NodeStatus.FAILURE)
					fail = true;
			}
			if(running)
				return NodeStatus.RUNNING;
			else if(fail)
				return NodeStatus.FAILURE;
			else
				return NodeStatus.RUNNING;
		}
	}
}