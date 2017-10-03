using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Animation/SetBool")]
	public class SetBool : BaseBehaviorNode
	{
		[SerializeField]
		private string parameter = "";
		[SerializeField]
		private bool enabled;
		Animator anim;

		public override Node Create(Vector2 pos)
		{
			SetBool node = CreateInstance<SetBool>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 60);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Parameter:");
			parameter = EditorGUILayout.TextField(parameter);
			GUILayout.Label("Enabled:");
			enabled = EditorGUILayout.Toggle(enabled);
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			anim = ((Transform)data.Get("_BTD_Agent")).GetComponent<Animator>();
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			anim.SetBool(parameter, enabled);
			return NodeStatus.SUCCESS;
		}
	}
}