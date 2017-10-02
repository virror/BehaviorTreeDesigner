using UnityEditor;
using UnityEngine;
using NodeEditorFramework;

// This namespace should most likely be removed for any custom nodes.
namespace BehavorTreeDesigner
{
	// This tells the editor if the node is hidden in the editor node dropdown and which path it will have.
	// NOTE: Needs to be changed to false to show up!
	[Node(true, "Behavior/Template")]
	public class Template : BaseBehaviorNode
	{
		// All fields that are visible in the node UI need to have the [SerializeField] tag.
		[SerializeField]
		private string exampleString;

		// Required function. Creates the node in the node editor.
		public override Node Create(Vector2 pos)
		{
			// This needs to use the same classas the script.
			Template node = CreateInstance<Template>();
			base.Init(node);

			// The last two parameters here sets the size of the node in the editor.
			node.rect = new Rect(pos.x, pos.y, 100, 95);
			// Example of an input node, last parameter is the x position of the input.
			node.CreateInput("In", "Behave", NodeSide.Top, 50);
			// Example of an output node, last parameter is the x position of the input.
			node.CreateOutput("Out", "Behave", NodeSide.Bottom, 50);

			return node;
		}

		// Optional function. Is required if you want parameters to show up for your node.
		protected override void NodeGUI()
		{
			GUILayout.Label("Example String:");
			exampleString = EditorGUILayout.TextField(exampleString);
		}

		// Optional function. Will run only once at game start, usefull for setting up data and references.
		public override void Init(BehaviorBlackboard data)
		{
			base.Init(data);
		}

		// Required function. This is where the actual node logic goes.
		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			return NodeStatus.SUCCESS;
		}
	}
}
