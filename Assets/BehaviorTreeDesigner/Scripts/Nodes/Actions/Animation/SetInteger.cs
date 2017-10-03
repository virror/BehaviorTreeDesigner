using UnityEditor;
using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Animation/SetInteger")]
	public class SetInteger : BaseBehaviorNode
	{
		[SerializeField]
		private string parameter = "";
		[SerializeField]
		private int value;
		Animator anim;

		public override Node Create(Vector2 pos)
		{
			SetInteger node = CreateInstance<SetInteger>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 60);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Parameter:");
			parameter = EditorGUILayout.TextField(parameter);
			GUILayout.Label("Value:");
			value = EditorGUILayout.IntField(value);
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			anim = ((Transform)data.Get("_BTD_Agent")).GetComponent<Animator>();
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			anim.SetInteger(parameter, value);
			return NodeStatus.SUCCESS;
		}
	}
}
