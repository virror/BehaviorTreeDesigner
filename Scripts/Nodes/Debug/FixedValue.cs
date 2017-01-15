using UnityEngine;
using UnityEditor;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Debug/TrueFalse")]
	public class FixedValue : BaseBehaviorNode
	{
		[SerializeField]
		private NodeStatus nodeStatus = NodeStatus.SUCCESS;

		public override Node Create(Vector2 pos)
		{
			FixedValue node = CreateInstance<FixedValue>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 80);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected internal override void NodeGUI()
		{
			base.NodeGUI();
			nodeStatus = (NodeStatus)EditorGUILayout.EnumPopup(nodeStatus);
		}

		public override void Init(Hashtable data)
		{

		}

		public override NodeStatus Tick()
		{	
			return nodeStatus;
		}
	}
} //>_