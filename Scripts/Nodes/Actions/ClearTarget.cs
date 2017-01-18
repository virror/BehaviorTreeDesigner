using UnityEngine;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/ClearTarget")]
	public class ClearTarget : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			ClearTarget node = CreateInstance<ClearTarget>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			data.AddClass<Transform>("Target", null);
			return NodeStatus.SUCCESS;
		}
	}
}
