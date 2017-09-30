using UnityEngine;

namespace BehavorTreeDesigner
{
	public class BehaviorManager : MonoBehaviour
	{
		public BehaviorCanvas behaviorTree;
		public float tickTime = 0.5f;
		public Transform agent;
		[HideInInspector]
		public BehaviorBlackboard data;

		private BaseBehaviorNode rootNode;

		private void Awake()
		{
			if(behaviorTree == null)
			{
				Debug.LogError("Behavor Tree Designer\nNo behavior assigned!");
				return;
			}
			if(agent == null)
			{
				Debug.LogError("Behavor Tree Designer\nNo agent assigned!");
				return;
			}

			data = new BehaviorBlackboard();
			data.Add("_BTD_Agent", agent);
			rootNode = behaviorTree.GetRootNode();
			rootNode.Init(data);
			InvokeRepeating("DoTick", 0, tickTime);
		}
		
		private void DoTick ()
		{
			rootNode.Tick(data);
		}
	}
}