using UnityEditor;
using UnityEngine;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Subtree")]
	public class Subtree : BaseBehaviorNode
	{
		[SerializeField]
		private BehaviorCanvas subTree;
		private BaseBehaviorNode subRoot;

		public override Node Create(Vector2 pos)
		{
			Subtree node = CreateInstance<Subtree>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 180, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 90);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Behavior Tree:");
			subTree = (BehaviorCanvas)EditorGUILayout.ObjectField(subTree, typeof(BehaviorCanvas), true);
		}

		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
			if(subTree == null)
			{
				Debug.LogError("Behavor Tree Designer\nNo subtree assigned!");
				return;
			}
			subRoot = subTree.GetRootNode();
			subRoot.Init(data);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			return subRoot.Tick(data);
		}
	}
}
