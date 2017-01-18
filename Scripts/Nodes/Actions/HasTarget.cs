using UnityEngine;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/HasTarget")]
	public class HasTarget : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			HasTarget node = CreateInstance<HasTarget>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform target = data.GetClass<Transform>("Target");
			if(target == null)
			{
				return NodeStatus.FAILURE;
			}
			else
			{
				return NodeStatus.SUCCESS;
			}
		}
	}
}
