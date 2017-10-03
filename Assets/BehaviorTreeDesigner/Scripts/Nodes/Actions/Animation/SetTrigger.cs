using UnityEditor;
using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Animation/SetTrigger")]
	public class SetTrigger : BaseBehaviorNode
	{
		[SerializeField]
		private string parameter = "";
		Animator anim;

		public override Node Create(Vector2 pos)
		{
			SetTrigger node = CreateInstance<SetTrigger>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 60);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Parameter:");
			parameter = EditorGUILayout.TextField(parameter);
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			anim = ((Transform)data.Get("_BTD_Agent")).GetComponent<Animator>();
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			anim.SetTrigger(parameter);
			return NodeStatus.SUCCESS;
		}
	}
}
