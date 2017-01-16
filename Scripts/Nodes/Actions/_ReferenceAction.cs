using UnityEngine;
using NodeEditorFramework;
using System.Collections;

namespace BehavorTreeDesigner
{
	[Node(false, "Behavior/Action/_RefAction")]
	public class _ReferenceAction : BaseBehaviorNode
	{
		public override Node Create(Vector2 pos)
		{
			_ReferenceAction node = CreateInstance<_ReferenceAction>();
			base.Init(node);

			//Set hte size of your node	
			node.rect = new Rect(pos.x, pos.y, 100, 80);
			
			//Create Inputs/Outputs
			//Actions always have one Input only and no outputs
			node.CreateInput("In", "Behave", NodeSide.Top, 50);

			return node;
		}

		//Use this to add custom gui elements to the node
		//Note that you will also have to increate the height of the 
		//node to get it to show incase you have an icon
		//Remove this if you dont need custom gui
		protected override void NodeGUI()
		{
		}

		//Do your stuff here
		public override NodeStatus Tick(BehaviorBlackboard data)
		{
			return NodeStatus.SUCCESS;
		}
	}
}
