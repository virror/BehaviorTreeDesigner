using UnityEngine;
using NodeEditorFramework;
using BehavorTreeDesigner;

public class BehaviorManager : MonoBehaviour
{
	public BehaviorCanvas behaviorTree;
	public float tickTime = 0.1f;
	public Transform agent;

	private BaseBehaviorNode rootNode;
	private BehaviorBlackboard data;

	private void Start ()
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
		data.Add<Transform>("Agent", agent);
		rootNode = behaviorTree.GetRootNode();
		rootNode.Init(data);
		InvokeRepeating("DoTick", 0, tickTime);
	}
	
	private void DoTick ()
	{
		rootNode.Tick(data);
	}
}
