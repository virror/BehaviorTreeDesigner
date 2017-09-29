using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Entries/HasEntry")]
	public class HasEntry : BaseBehaviorNode
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
			HasEntry node = CreateInstance<HasEntry>();
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
					GUILayout.Label("Not null");
					break;
				default:
					break;
			}
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			NodeStatus retVal = NodeStatus.FAILURE;
			switch (entType)
			{
				case EntryType.BOOL:
					if(boolEntry == (bool)data.Get(entry))
						retVal = NodeStatus.SUCCESS;
					break;
				case EntryType.INTEGER:
					if(intEntry == (int)data.Get(entry))
						retVal = NodeStatus.SUCCESS;
					break;
				case EntryType.FLOAT:
					if(floatEntry == (float)data.Get(entry))
						retVal = NodeStatus.SUCCESS;
					break;
				case EntryType.CLASS:
					if(data.Get(entry) != null)
						retVal = NodeStatus.SUCCESS;
					break;
				default:
					retVal = NodeStatus.ERROR;
					break;
			}
			return retVal;
		}
	}
}
