using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner.Example
{
	[Node(false, "Behavior/Action/Shoot")]
	public class Shoot : BaseBehaviorNode
	{
		private GameObject bullet;

		public override Node Create(Vector2 pos)
		{
			Shoot node = CreateInstance<Shoot>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			bullet = Resources.Load<GameObject>("Bullet");
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform agent = (Transform)data.Get("_BTD_Agent");
			GameObject.Instantiate(bullet, agent.position + new Vector3(0, 1, 0), agent.rotation);
			return NodeStatus.SUCCESS;
		}
	}
}
