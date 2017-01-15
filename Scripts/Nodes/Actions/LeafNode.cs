using UnityEngine;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Action")]
	public class LeafNode : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			LeafNode node = CreateInstance<LeafNode>();
			base.Init(node);
			
			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		public override void Init(Hashtable data)
		{

		}

		public override NodeStatus Tick()
		{
			return NodeStatus.SUCCESS;
		}
	}
}
