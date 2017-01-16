using UnityEngine;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Shoot")]
	public class Shoot : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			Shoot node = CreateInstance<Shoot>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform agent = data.Get<Transform>("Agent");
			GameObject bullet = Resources.Load<GameObject>("Bullet");
			GameObject.Instantiate(bullet, agent.position + new Vector3(0, 1, 0), agent.rotation);
			return NodeStatus.SUCCESS;
		}
	}
}
