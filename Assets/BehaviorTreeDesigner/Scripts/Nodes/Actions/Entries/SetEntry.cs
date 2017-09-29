using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Entries/SetEntry")]
	public class SetEntry : BaseBehaviorNode
	{
		[SerializeField]
		private string entry = "";
		[SerializeField]
		private EntryType entType;
		[SerializeField]
		private bool boolEntry = false;
		[SerializeField]
		private int intEntry = 0;
		[SerializeField]
		private float floatEntry = 0;

		public override Node Create(Vector2 pos)
		{
			SetEntry node = CreateInstance<SetEntry>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 100, 130);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
			GUILayout.Label("Type:");
			entType = (EntryType)EditorGUILayout.EnumPopup(entType);
			switch (entType)
			{
				case EntryType.BOOL:
					GUILayout.Label("Value:");
					boolEntry = EditorGUILayout.Toggle(boolEntry);
					break;
				case EntryType.INTEGER:
					GUILayout.Label("Value:");
					intEntry = EditorGUILayout.IntField(intEntry);
					break;
				case EntryType.FLOAT:
					GUILayout.Label("Value:");
					floatEntry = EditorGUILayout.FloatField(floatEntry);
					break;
				case EntryType.CLASS:
					GUILayout.Label("Value:");
					GUILayout.Label("null");
					break;
				default:
					break;
			}
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			switch (entType)
			{
				case EntryType.BOOL:
					data.Add(entry, boolEntry);
					break;
				case EntryType.INTEGER:
					data.Add(entry, intEntry);
					break;
				case EntryType.FLOAT:
					data.Add(entry, floatEntry);
					break;
				case EntryType.CLASS:
					data.Add(entry, null);
					break;
				default:
					return NodeStatus.ERROR;
			}
			return NodeStatus.SUCCESS;
		}
	}
}
