using UnityEngine;
using UnityEditor;
using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/Entries/TriggerToEntry")]
	public class TriggerToEntry : BaseBehaviorNode
	{
		[SerializeField]
		private string childName = "";
		[SerializeField]
		private string entry = "";

		public override Node Create(Vector2 pos)
		{
			TriggerToEntry node = CreateInstance<TriggerToEntry>();
			base.Init(node);

			node.rect = new Rect(pos.x, pos.y, 120, 95);
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		protected override void NodeGUI()
		{
			GUILayout.Label("Child name:");
			childName = EditorGUILayout.TextField(childName);
			GUILayout.Label("Entry:");
			entry = EditorGUILayout.TextField(entry);
		}

		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			Transform agent = (Transform)data.Get("Agent");
			Transform child = agent.Find(childName);
			
			if(child != null)
			{
				ColliderHelper colHelper = child.GetComponent<ColliderHelper>();
				if(colHelper != null)
				{
					if(colHelper.trigger != null)
					{
						data.Add(entry, colHelper.trigger);
						return NodeStatus.SUCCESS;
					}
					else
					{
						return NodeStatus.FAILURE;
					}
				}
				else
				{
					Debug.LogError("Behavor Tree Designer\nNo ColliderHelper script found on child: " + childName + " on object: " + agent.name);
					return NodeStatus.ERROR;
				}
			}
			else
			{
				Debug.LogError("Behavor Tree Designer\nChild: " + childName + " not found on object: " + agent.name);
				return NodeStatus.ERROR;
			}
		}
	}
}
