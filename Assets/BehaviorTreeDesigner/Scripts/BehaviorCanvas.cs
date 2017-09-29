using NodeEditorFramework;

namespace BehavorTreeDesigner
{
	[NodeCanvasType("Behavior Canvas")]
	public class BehaviorCanvas : NodeCanvas
	{
		public BaseBehaviorNode GetRootNode()
		{
			foreach(Node node in this.nodes)
			{
				if(node is Root)
				{
					return (BaseBehaviorNode)node;
				}
			}
			return null;
		}	
	}
}
